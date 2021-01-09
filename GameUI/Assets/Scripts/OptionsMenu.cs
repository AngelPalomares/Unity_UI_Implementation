using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public Toggle FullscreenToggle;
    public Toggle VsyncToggle;

    public ResItem[] resolutions;

    public int SelectedResolution;

    public Text ResolutionText;

    public AudioMixer theMixer;

    public Slider MasterSlider, musicSlider, SFXSlider;

    public Text masterLabel, musicLabel, SFXLabel;

    public AudioSource SFXLoop;



    // Start is called before the first frame update
    void Start()
    {
        FullscreenToggle.isOn = Screen.fullScreen;

        if (QualitySettings.vSyncCount == 0)
        {
            VsyncToggle.isOn = false;
        }
        else
        {
            VsyncToggle.isOn = true;
        }

        //search for resolution in list
        bool foundRes = false;

        for(int i = 0; i < resolutions.Length; i++)
        {
            if(Screen.width == resolutions[i].horizontal && Screen.width == resolutions[i].vertical)
            {
                foundRes = true;

                SelectedResolution = i;

                if (SelectedResolution == 0)
                {
                    ResolutionText.text = "1920 X 1080";
                }
                else if (SelectedResolution == 1)
                {
                    ResolutionText.text = "1280 X 720";
                }
                else if (SelectedResolution == 2)
                {
                    ResolutionText.text = "854 X 480";
                }
            }
        }

        if (!foundRes)
        {
            ResolutionText.text = Screen.width.ToString() + " x " + Screen.height.ToString();
        }


        if(PlayerPrefs.HasKey("MasterVol"))
        {
            theMixer.SetFloat("MasterVol", PlayerPrefs.GetFloat("MasterVol"));
            MasterSlider.value = PlayerPrefs.GetFloat("MasterVol");
        }

        if(PlayerPrefs.HasKey("MusicVol"))
        {
            theMixer.SetFloat("MusicVol", PlayerPrefs.GetFloat("MusicVol"));
            musicSlider.value = PlayerPrefs.GetFloat("MusicVol");
        }    


        if(PlayerPrefs.HasKey("SFXVol"))
        {
            theMixer.SetFloat("SFXVol", PlayerPrefs.GetFloat("MusicVol"));
            SFXSlider.value = PlayerPrefs.GetFloat("SFXVol");
        }

        masterLabel.text = (MasterSlider.value + 80).ToString();
        musicLabel.text = (musicSlider.value + 80).ToString();
        SFXLabel.text = (musicSlider.value + 80).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResLeft()
    {
        SelectedResolution--;
        if (SelectedResolution < 0)
        {
            SelectedResolution = 0;
        }

        if (SelectedResolution == 0)
        {
            ResolutionText.text = "1920 X 1080";
        }
        if (SelectedResolution == 1)
        {
            ResolutionText.text = "1280 X 720";
        }
        if (SelectedResolution == 2)
        {
            ResolutionText.text = "854 X 480";
        }
    }

    public void ResRight()
    {
        SelectedResolution++;
        if (SelectedResolution > resolutions.Length - 1)
        {
            SelectedResolution = resolutions.Length - 1;
        }

        if (SelectedResolution == 0)
        {
            ResolutionText.text = "1920 X 1080";
        }
        if (SelectedResolution == 1)
        {
            ResolutionText.text = "1280 X 720";
        }
        if (SelectedResolution == 2)
        {
            ResolutionText.text = "854 X 480";
        }
    }

    public void ApplyGraphics()
    {
        //apply fullscreen
        //Screen.fullScreen = FullscreenToggle.isOn;

        //apply Vsync
        if(VsyncToggle.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }

        //set Resolutions
        Screen.SetResolution(resolutions[SelectedResolution].horizontal, resolutions[SelectedResolution].vertical, FullscreenToggle.isOn);
    }

    public void SetMasterVolume()
    {
        masterLabel.text = (MasterSlider.value + 80).ToString();

        theMixer.SetFloat("MasterVol", MasterSlider.value);

        PlayerPrefs.SetFloat("MasterVol", MasterSlider.value);

    }

    public void SetMusicVolume()
    {
        musicLabel.text = (musicSlider.value + 80).ToString();

        theMixer.SetFloat("MusicVol", musicSlider.value);

        PlayerPrefs.SetFloat("MusicVol", musicSlider.value);

    }

    public void SetSFXVolume()
    {
        SFXLabel.text = (SFXSlider.value + 80).ToString();

        theMixer.SetFloat("SFXVol", SFXSlider.value);

        PlayerPrefs.SetFloat("SFXVol", SFXSlider.value);

        PlayerPrefs.SetFloat("SFXVol", SFXSlider.value);

    }

    public void PlaySFXLoop()
    {
        SFXLoop.Play();
    }

    public void StopSFXLoop()
    {
        SFXLoop.Stop();
    }

}

[System.Serializable]
public class ResItem {
    public int horizontal, vertical;
}

