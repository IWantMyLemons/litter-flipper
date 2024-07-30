using UnityEngine;
using UnityEngine.UI;

public class VolumeBar : MonoBehaviour
{
    public Image volumeBarImage; // Assign the volume bar Image component in the Inspector
    public AudioSource audioSource; // Assign your AudioSource in the Inspector
    public Sprite[] volumeSprites; // Assign the volume sprites in the Inspector

    private const float INITIAL_VOLUME_LEVEL = 0.5f;
    private const float VOLUME_STEP = 0.1f;

    private float volumeLevel = INITIAL_VOLUME_LEVEL; // initial volume level

    private void Start()
    {
        // Initialize the audio source volume
        audioSource.volume = volumeLevel;
        UpdateVolumeBar();
    }

    public void IncreaseVolume()
    {
        Debug.Log("IncreaseVolume called");
        volumeLevel = Mathf.Min(volumeLevel + VOLUME_STEP, 1f);
        SetVolume(volumeLevel);
        AudioManager.Instance.PlaySFX("dink");
    }

    public void DecreaseVolume()
    {
        Debug.Log("DecreaseVolume called");
        volumeLevel = Mathf.Max(volumeLevel - VOLUME_STEP, 0f);
        SetVolume(volumeLevel);
        AudioManager.Instance.PlaySFX("dink");
    }

    private void SetVolume(float level)
    {
        audioSource.volume = level;
        UpdateVolumeBar();
    }

    private void UpdateVolumeBar()
    {
        if (volumeSprites.Length == 0)
        {
            Debug.LogError("Volume sprites array is empty!");
            return;
        }

        int spriteIndex = (int)(volumeLevel * (volumeSprites.Length - 1));
        volumeBarImage.sprite = volumeSprites[spriteIndex];
    }
}

//note 4 ez ref https://youtu.be/rdX7nhH6jdM?t=399