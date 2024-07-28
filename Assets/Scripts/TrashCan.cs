using UnityEngine;

public class TrashCan : MonoBehaviour
{
    public string correctTrashCategory;

    public void CheckCorrectTrash(TrashItem trashItem)
    {
        foreach (string category in trashItem.trashCategories)
        {
            if (category == correctTrashCategory)
            {
                // Correct drop
                GameManager.Instance.CorrectDrop();
                Destroy(trashItem.gameObject);
                return;
            }
        }
        // Incorrect drop
        Destroy(trashItem.gameObject);
        GameManager.Instance.WrongDrop();
    }
}
