using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsScript : MonoBehaviour
{
    public GameObject soundOf, soundOn;
    private void Start()
    {
        if(Tempik.soundVol == 0)
        {
            AudioListener.volume = 0;
            soundOf.SetActive(true);
            soundOn.SetActive(false);
        }
    }
    public void SoundOff()
    {
        Tempik.soundVol = 0;
        AudioListener.volume = 0;
        soundOf.SetActive(true);
        soundOn.SetActive(false);
    }
    public void SoundOn()
    {
        Tempik.soundVol = 1;
        AudioListener.volume = 1f;
        soundOf.SetActive(false);
        soundOn.SetActive(true);
    }
}
