using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonNav : MonoBehaviour
{
    [SerializeField] GameObject settingMenu;
    [SerializeField] GameObject creditMenu;

    public void PlayButton()
    {
        SceneManager.LoadScene("Level Select");
    }

    public void SettingButton()
    {
       settingMenu.SetActive(true);
    }

    public void CloseSettingButton()
    {
       settingMenu.SetActive(false);
    }

    public void CreditsButton()
    {
        creditMenu.SetActive(true);
    }
    public void CloseCreditsButton()
    {
        creditMenu.SetActive(false);
    }
}

