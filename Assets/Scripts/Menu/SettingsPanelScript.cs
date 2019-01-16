using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;

public class SettingsPanelScript : MonoBehaviour
{
    // for volume
    public AudioMixer masterAudioMixer;
    public Slider volumeSlider;

    // for fullscreen
    public Toggle fullscreenToggle;

    // for resolution
    public Dropdown resolutionsDropdown;
    Resolution[] resolutions;

    void Start()
    {
        // get volume from master
        float volume;
        masterAudioMixer.GetFloat("volumeMaster", out volume);

        // odd value
        if (volume > 0)
            volume = 0;
        if (volume < -80)
            volume = -80;

        volumeSlider.value = volume;

        // get fullscreen or not
        fullscreenToggle.isOn = Screen.fullScreen;

        // get screen resolution
        resolutions = Screen.resolutions;
        resolutionsDropdown.ClearOptions();

        int curRes = 0;
        List<string> resolutionsString = new List<string>();
        for (int i = 0; i < resolutions.Length; ++i)
        {
            // current resolution
            if (Screen.currentResolution.width == resolutions[i].width
            && Screen.currentResolution.height == resolutions[i].height
            && Screen.currentResolution.refreshRate == resolutions[i].refreshRate)
                curRes = i;

            // convert to string
            resolutionsString.Add(resolutions[i].ToString());
        }

        // add res to dropdown
        resolutionsDropdown.AddOptions(resolutionsString);
        resolutionsDropdown.value = curRes;
        resolutionsDropdown.RefreshShownValue();
    }

    public void SetVolume(float volume)
    {
        masterAudioMixer.SetFloat("volumeMaster", volume);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int resIndex)
    {
        Resolution res = resolutions[resIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }
}
