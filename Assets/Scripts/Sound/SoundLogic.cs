using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLogic : MonoBehaviour
{
    public List<AudioSource> sounds; 
    void Start()
    {
    
       
     DontDestroyOnLoad(gameObject);
    
    }
    //0 - дробовик 1 - мелишка 2 - кнопка 3 - пистолет 4 - бомба

    
}
