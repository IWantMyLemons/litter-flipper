using UnityEngine;

public class TrashItem : MonoBehaviour
{
    public string trashType; // Assign this in the inspector or via another script

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TrashCan trashCan = collision.collider.GetComponent<TrashCan>();
        if (trashCan != null)
        {
            trashCan.CheckCorrectTrash(this);
        }
    }
}
