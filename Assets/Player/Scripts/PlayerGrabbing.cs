using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class PlayerGrabbing : MonoBehaviour
{
    [Tooltip("Offset of the object")]
    public Vector2 grabOffset;
    [Tooltip("Collider used to grab stuff")]
    public Collider2D grabCollider;
    [Tooltip("Filter for stuff grabbing")]
    public ContactFilter2D contactFilter;
    [Tooltip("Velocity applied to objects")]
    public float throwVelocity;

    Transform inHand;
    Animator animator;

    TrashItem grabbedItem; //trash can open close related

    public void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void Update()
    {
        animator.SetBool("isHoldingObject", !inHand.IsUnityNull());

        if (Input.GetButtonDown("Grab"))
        {
            if (inHand.IsUnityNull())
            {
                GrabObject();
            }
            else
            {
                DropObject();
            }
        }
    }

    void GrabObject()
    {
        Collider2D[] collisions = new Collider2D[5];
        int n_collisions = grabCollider.OverlapCollider(contactFilter, collisions);
        if (n_collisions == 0) return;

        AudioManager.Instance.PlaySFX("grab");

        Collider2D closest = collisions[0];
        for (int i = 1; i < n_collisions; i++)
        {
            Vector3 curr_distance = collisions[i].transform.position - transform.position;
            Vector3 closest_distance = closest.transform.position - transform.position;

            if (curr_distance.magnitude < closest_distance.magnitude)
            {
                closest = collisions[i];
            }
        }

        inHand = closest.transform;
        inHand.SetParent(transform);
        inHand.localPosition = grabOffset;

        //trash can open close related
        if (inHand.TryGetComponent<TrashItem>(out grabbedItem))
        {
            TrashCan[] trashCans = FindObjectsOfType<TrashCan>();
            foreach (var trashCan in trashCans)
            {
                // Deactivate cap only for the correct trash can
                if (Array.Exists(grabbedItem.trashCategories, category => category == trashCan.correctTrashCategory))
                {
                    trashCan.DeactivateCap(grabbedItem.trashCategories);
                }
                else
                {
                    trashCan.ActivateCap();
                }
            }
        }

        // Velocity set to 0 to stop object from flying off hand
        inHand.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        // Disable rigidbody to prevent premature dropping
        inHand.GetComponent<Rigidbody2D>().simulated = false;
    }

    void DropObject()
    {
        AudioManager.Instance.PlaySFX("drop");
        
        inHand.SetParent(transform.parent);
        inHand.GetComponent<Rigidbody2D>().simulated = true;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 throwDirection = mousePosition - inHand.position;

        Vector2 throwVector = throwDirection.normalized * throwVelocity;
        inHand.GetComponent<Rigidbody2D>().velocity = throwVector;
        inHand = null;

        grabbedItem = null;
    }

}