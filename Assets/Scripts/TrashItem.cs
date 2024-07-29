using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashItem : MonoBehaviour
{
    public string[] trashCategories; // Assign these in the inspector

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TrashCan trashCan = collision.collider.GetComponent<TrashCan>();
        if (trashCan != null)
        {
            trashCan.CheckCorrectTrash(this);
        }
    }
    private void OnDestroy()
    {
        // Reactivate caps on all trash cans when item is destroyed
        TrashCan[] trashCans = FindObjectsOfType<TrashCan>();
        foreach (var trashCan in trashCans)
        {
            trashCan.ActivateCap();
        }
    }
}
