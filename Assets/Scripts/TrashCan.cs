using UnityEngine;

public class TrashCan : MonoBehaviour
{
    public string correctTrashType;

    public void CheckCorrectTrash(TrashItem trashItem)
    {
        if (trashItem.trashType == correctTrashType)
        {
            // Correct drop
            GameManager.Instance.CorrectDrop();
            Destroy(trashItem.gameObject);
        }
        else
        {
            // Incorrect drop
            GameManager.Instance.WrongDrop();
            Destroy(trashItem.gameObject);
        }
    }
}
