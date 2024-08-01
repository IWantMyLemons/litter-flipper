using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BookNavButton : MonoBehaviour
{
    public static BookNavButton Instance;
    [SerializeField] GameObject bookCover;
    [SerializeField] GameObject infoPage;
    [SerializeField] GameObject trashInfoPage;
    [SerializeField] GameObject fishInfoPage;
    [SerializeField] GameObject infoButton;
    [SerializeField] GameObject trashInfoButton;
    [SerializeField] GameObject fishInfoButton;
    [SerializeField] GameObject infoButtonPrev;
    [SerializeField] GameObject trashInfoButtonPrev;
    [SerializeField] GameObject prevPageButton;
    [SerializeField] GameObject nextPageButton;
    [SerializeField] GameObject closeBookButton;
    [SerializeField] GameObject darkPanel;
    [SerializeField] GameObject openBookButton;

    [SerializeField] GameObject[] trashPages;
    [SerializeField] GameObject[] infoPages;
    [SerializeField] GameObject[] fishPages;

    private int pageNum = 0;
    void Awake()
    {
        Instance = this;
    }


    public void BookOpenButton()
    {
        bookCover.SetActive(true);
        infoPage.SetActive(false);
        trashInfoPage.SetActive(false);
        fishInfoPage.SetActive(false);

        infoButton.SetActive(true);
        trashInfoButton.SetActive(false);
        fishInfoButton.SetActive(false);
        infoButtonPrev.SetActive(false);
        trashInfoButtonPrev.SetActive(false);
        closeBookButton.SetActive(false);
        prevPageButton.SetActive(false);
        nextPageButton.SetActive(false);
        darkPanel.SetActive(true);

        Time.timeScale = 0;
        AudioManager.Instance.PlaySFX("book");
    }

    public void BookCloseButton()
    {
        bookCover.SetActive(false);
        infoPage.SetActive(false);
        trashInfoPage.SetActive(false);
        fishInfoPage.SetActive(false);

        infoButton.SetActive(false);
        trashInfoButton.SetActive(false);
        fishInfoButton.SetActive(false);
        infoButtonPrev.SetActive(false);
        trashInfoButtonPrev.SetActive(false);
        closeBookButton.SetActive(false);
        prevPageButton.SetActive(false);
        nextPageButton.SetActive(false);
        darkPanel.SetActive(false);
        Time.timeScale = 1;
        AudioManager.Instance.PlaySFX("koob");
    }

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
        closeBookButton.SetActive(true);
        prevPageButton.SetActive(true);
        nextPageButton.SetActive(true);

        infoPages[0].SetActive(true);

        for (int i = 1; i < infoPages.Length; i++)
        {
            infoPages[i].SetActive(false);
        }

        pageNum = 0;
        Time.timeScale = 0;
        AudioManager.Instance.PlaySFX("page");
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
        closeBookButton.SetActive(true);
        prevPageButton.SetActive(true);
        nextPageButton.SetActive(true);

        trashPages[0].SetActive(true);

        for (int i = 1; i < trashPages.Length; i++)
        {
            trashPages[i].SetActive(false);
        }

        pageNum = 0;
        Time.timeScale = 0;
        AudioManager.Instance.PlaySFX("page");
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
        closeBookButton.SetActive(true);
        prevPageButton.SetActive(true);
        nextPageButton.SetActive(true);

        fishPages[0].SetActive(true);

        for (int i = 1; i < fishPages.Length; i++)
        {
            fishPages[i].SetActive(false);
        }

        pageNum = 0;
        Time.timeScale = 0;
        AudioManager.Instance.PlaySFX("page");
    }

    public void NextPageButton()
    {
        AudioManager.Instance.PlaySFX("page");
        if (infoPage.activeSelf)
        {
            infoPages[pageNum].SetActive(false);
            pageNum++;
            if (pageNum >= infoPages.Length)
            {
                pageNum = 0;
                TrashInfoButton();
            }
            else
            {
                infoPages[pageNum].SetActive(true);
            }
        }
        else if (trashInfoPage.activeSelf)
        {
            trashPages[pageNum].SetActive(false);
            pageNum++;
            if (pageNum >= trashPages.Length)
            {
                pageNum = 0;
                FishInfoButton();
            }
            else
            {
                trashPages[pageNum].SetActive(true);
            }
        }
        else if (fishInfoPage.activeSelf)
        {
            fishPages[pageNum].SetActive(false);
            pageNum++;
            if (pageNum >= fishPages.Length)
            {
                pageNum = fishPages.Length - 1;
                fishPages[pageNum].SetActive(true);
            }
            else
            {
                fishPages[pageNum].SetActive(true);
            }
        }
    }

    public void PrevPageButton()
    {
        AudioManager.Instance.PlaySFX("page");
        if (infoPage.activeSelf)
        {
            infoPages[pageNum].SetActive(false);
            pageNum--;
            if (pageNum < 0)
            {
                pageNum = 0;
                infoPages[pageNum].SetActive(true);
            }
            else
            {
                infoPages[pageNum].SetActive(true);
            }
        }
        else if (trashInfoPage.activeSelf)
        {
            trashPages[pageNum].SetActive(false);
            pageNum--;
            if (pageNum < 0)
            {
                FishInfoButton();
                pageNum = fishPages.Length - 1;
                fishPages[pageNum].SetActive(true);
            }
            else
            {
                trashPages[pageNum].SetActive(true);
            }
        }
        else if (fishInfoPage.activeSelf)
        {
            fishPages[pageNum].SetActive(false);
            pageNum--;
            if (pageNum < 0)
            {
                InfoButton();
                pageNum = infoPages.Length - 1;
                infoPages[pageNum].SetActive(true);
            }
            else
            {
                fishPages[pageNum].SetActive(true);
            }
        }
    }
}
