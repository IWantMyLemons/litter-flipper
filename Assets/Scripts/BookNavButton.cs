using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BookNavButton : MonoBehaviour
{
    [SerializeField] GameObject bookCover;
    [SerializeField] GameObject infoPage;
    [SerializeField] GameObject trashInfoPage;
    [SerializeField] GameObject fishInfoPage;
    [SerializeField] GameObject infoButton;
    [SerializeField] GameObject trashInfoButton;
    [SerializeField] GameObject fishInfoButton;
    [SerializeField] GameObject infoButtonPrev;
    [SerializeField] GameObject trashInfoButtonPrev;

    //button navigator in the book
    public void InfoButton()
    {
        bookCover.SetActive(false);
        infoPage.SetActive(true);
        trashInfoPage.SetActive(false);
        fishInfoPage.SetActive(false);

        infoButton.SetActive(false);
        trashInfoButton.SetActive(true);
        fishInfoButton.SetActive(true);
        infoButtonPrev.SetActive(false);
        trashInfoButtonPrev.SetActive(false);
        Time.timeScale = 0;
    }

    public void TrashInfoButton()
    {
        bookCover.SetActive(false);
        infoPage.SetActive(false);
        trashInfoPage.SetActive(true);
        fishInfoPage.SetActive(false);

        infoButton.SetActive(false);
        trashInfoButton.SetActive(false);
        fishInfoButton.SetActive(true);
        infoButtonPrev.SetActive(true);
        trashInfoButtonPrev.SetActive(false);
        Time.timeScale = 0;
    }

    public void FishInfoButton()
    {
        bookCover.SetActive(false);
        infoPage.SetActive(false);
        trashInfoPage.SetActive(false);
        fishInfoPage.SetActive(true);

        infoButton.SetActive(false);
        trashInfoButton.SetActive(false);
        fishInfoButton.SetActive(false);
        infoButtonPrev.SetActive(true);
        trashInfoButtonPrev.SetActive(true);
        Time.timeScale = 0;
    }
}
