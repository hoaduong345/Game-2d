using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuEvents : MonoBehaviour
{
    public Slider SliderSFX;
    public Slider SliderMusic;
    public AudioMixer mixerSFX;
    public AudioMixer mixerMusic;

    private void Start()
    {
        SliderSFX.value = Shared.SaveValueSFX;
        SliderMusic.value = Shared.SaveValueMusic;
    }
    public void SetSFX()
    {
        Shared.SaveValueSFX = SliderSFX.value;
        mixerSFX.SetFloat("volume", SliderSFX.value);
    }
    public void SetMusic()
    {
        Shared.SaveValueMusic = SliderMusic.value;
        mixerMusic.SetFloat("volume", SliderMusic.value);
    }
}