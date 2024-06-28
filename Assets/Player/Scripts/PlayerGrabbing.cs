using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerGrabbing : MonoBehaviour
{
    [Tooltip("Offset of the object")]
    public Vector2 grabOffset;
    [Tooltip("Collider used to grab stuff")]
    public Collider2D grabCollider;
    [Tooltip("Filter for stuff grabbing")]
    public ContactFilter2D contactFilter;

    Transform inHand;

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
    }

    void DropObject()
    {
        inHand.SetParent(transform.parent);
        inHand = null;
    }
}