using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;
public class MainMenu : MonoBehaviour
{
    public GameObject Menu,soundOf,soundOn;
    public YandexGame YG;
   private void Start()
    {
        
        Menu.SetActive(false);
        if (Tempik.soundVol == 0)
        {
            AudioListener.volume = 0;
            soundOf.SetActive(true);
            soundOn.SetActive(false);
        }
        
    }
    public void Restart()
    {
        Time.timeScale = 1;
        FindAnyObjectByType<IinputController>().canInput = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OpenOrCloseMenu(bool open)
    {
        Menu.SetActive(open); // true - оно открылось, false - закрылось
        if(open == true)
        {
            Cursor.lockState = CursorLockMode.None;
            FindAnyObjectByType<IinputController>().canInput = false;
            Time.timeScale = 0;


        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
            FindAnyObjectByType<IinputController>().canInput = true;
        }
    }
    
    public void MainMenuScene()
    {
        Instantiate(YG);
        YG._FullscreenShow();
        SceneManager.LoadScene(1);
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
