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
}
