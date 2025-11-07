using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider volumeSlider;

    public void SetVolume(float sliderValue)
    {
        // Logarithmic scale for better audio control
        mixer.SetFloat("Volume", Mathf.Log10(sliderValue) * 20);
    }

    private void Start()
    {
        // Set default slider value (you can customize this)
        volumeSlider.value = PlayerPrefs.GetFloat("volume", 0.75f);
        SetVolume(volumeSlider.value);
    }

    private void OnDisable()
    {
        // Save volume when object is disabled
        PlayerPrefs.SetFloat("volume", volumeSlider.value);
    }
}
