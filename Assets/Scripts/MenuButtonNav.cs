using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonNav : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("Level Select");
    }

    public void SettingButton()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void CreditsButton()
    {
        SceneManager.LoadScene("Level 1");
    }
}

