using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartMenu : MonoBehaviour
{

    public void StartMenuButt()
    {
        FindAnyObjectByType<SoundLogic>().sounds[2].Play();
        SceneManager.LoadScene(1);
    }

}
