using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrabbing : MonoBehaviour
{
    [Tooltip("Offset of the object")]
    public Vector2 grabOffset;
    [Tooltip("Collider used to grab stuff")]
    public Collider2D grabCollider;
    [Tooltip("Filter for stuff grabbing")]
    public ContactFilter2D contactFilter;
    [Tooltip("Multiplier on force applied")]
    public float throwForce;

    Transform inHand;
    
    TrashItem grabbedItem; //trash can open close related

    public void Update()
    {
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
        Collider2D[] collision = new Collider2D[1];
        bool found_object = grabCollider.OverlapCollider(contactFilter, collision) == 1;
        if (!found_object) return;

        inHand = collision[0].transform;
        inHand.SetParent(transform);
        inHand.localPosition = grabOffset;

        //trash can open close related
        grabbedItem = inHand.GetComponent<TrashItem>();

        if (grabbedItem != null)
        {
            TrashCan[] trashCans = FindObjectsOfType<TrashCan>();
            foreach (var trashCan in trashCans)
            {
                // Deactivate cap only for the correct trash can
                if (System.Array.Exists(grabbedItem.trashCategories, category => category == trashCan.correctTrashCategory))
                {
                    trashCan.DeactivateCap(grabbedItem.trashCategories);
                }
                else{
                    trashCan.ActivateCap();
                }
            }
        }

        // Velocity set to 0 to stop object from flying off hand
        collision[0].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    void DropObject()
    {
        inHand.SetParent(transform.parent);
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 throwDirection = mousePosition - inHand.position;

        // StartCoroutine(ReactivateCapsAfterDrop()); //close trash can if player drop trash after 5 sec
        
        inHand.GetComponent<Rigidbody2D>().AddForce(throwDirection * throwForce);
        inHand = null;  
        
        grabbedItem = null;
        
    }

    // private IEnumerator ReactivateCapsAfterDrop()
    // {
    //     yield return new WaitForSeconds(5);
    //     TrashCan[] trashCans = FindObjectsOfType<TrashCan>();
    //     foreach (var trashCan in trashCans)
    //     {
    //         trashCan.ActivateCap();
    //     }
    // }

}