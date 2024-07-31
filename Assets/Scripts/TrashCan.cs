using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class TrashCan : MonoBehaviour
{
    public string correctTrashCategory;
    public GameObject trashCap;
    public Text warningText; 

    private void Start()
    {
        if (warningText != null)
        {
            warningText.gameObject.SetActive(false);
        }

        ActivateCap();
    }


    public void CheckCorrectTrash(TrashItem trashItem)
    {
        bool isCorrectCategory = false;

        foreach (string category in trashItem.trashCategories)
        {
            if (category == correctTrashCategory)
            {
                isCorrectCategory = true;
                break;
            }
        }

        if (correctTrashCategory == "sea")
        {
            if (!isCorrectCategory)
            {
                GameManager.Instance.WrongDrop();
                Destroy(trashItem.gameObject);
            }
            else{
                GameManager.Instance.CorrectDrop();
                Destroy(trashItem.gameObject);
            }
        }
        else if (correctTrashCategory == "igloo")
        {
            if (!isCorrectCategory)
            {
                // Do nothing, item will not be destroyed, and player will not lose life
            }
            else{
                GameManager.Instance.CorrectDrop();
                //activate igloo behaviour script(?) here
            }
        }
        else
        {
            if (isCorrectCategory)
            {
                if (trashCap != null)
                {
                    trashCap.SetActive(false);
                }
                GameManager.Instance.CorrectDrop();
                Destroy(trashItem.gameObject);
            }
            else
            {
                ActivateCap();
                if (System.Array.Exists(trashItem.trashCategories, category => category == "igloo") || System.Array.Exists(trashItem.trashCategories, category => category == "sea"))
                {
                    Debug.Log("igloo or sea");
                    StartCoroutine(ShowWarning("--- wrong place! ---"));
                    AudioManager.Instance.PlaySFX("bong");
                }

                else{
                    Debug.Log("trash");
                    StartCoroutine(ShowWarning("--- wrong trash can! ---"));
                    AudioManager.Instance.PlaySFX("bong");
                }
            }
        }
    }

    public void DeactivateCap(string[] itemCategories)
    {
        if (trashCap == null) return;

        foreach (string category in itemCategories)
        {
            if (category == correctTrashCategory)
            {
                trashCap.SetActive(false);
                return;
            }
        }
    }

    public void ActivateCap()
    {
        if (trashCap != null && correctTrashCategory != "sea" && correctTrashCategory != "igloo")
        {
            trashCap.SetActive(true);
        }
    }

    private IEnumerator ShowWarning(string message)
    {
        if (warningText != null)
        {
            warningText.text = message;
            warningText.gameObject.SetActive(true);
            yield return new WaitForSeconds(3);
            warningText.gameObject.SetActive(false);
        }
    }
}