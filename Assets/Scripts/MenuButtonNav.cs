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
        AudioManager.Instance.PlaySFX("dink");
        SceneManager.LoadScene("Level Select");
    }

    public void SettingButton()
    {
        AudioManager.Instance.PlaySFX("dink");
        settingMenu.SetActive(true);
    }

    public void CloseSettingButton()
    {
        AudioManager.Instance.PlaySFX("clop");
        settingMenu.SetActive(false);
    }

    public void CreditsButton()
    {
        AudioManager.Instance.PlaySFX("dink");
        creditMenu.SetActive(true);
    }
    public void CloseCreditsButton()
    {
        AudioManager.Instance.PlaySFX("clop");
        creditMenu.SetActive(false);
    }
}

