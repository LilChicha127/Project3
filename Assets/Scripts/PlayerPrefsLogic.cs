using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerPrefsLogic : MonoBehaviour
{
    
     void Start()
    {
        GettPlPr();
        //PlayerPrefs.DeleteAll();
    }

    
    void GettPlPr()
    {
        if (PlayerPrefs.GetInt("maxScene") > 0)
        {
            Tempik.currentScene = PlayerPrefs.GetInt("currentScene");
            Tempik.maxOpenScene = PlayerPrefs.GetInt("maxScene");
            Tempik.tempScene = PlayerPrefs.GetInt("tempScene");
        }

        //PlayerPrefs.DeleteKey("currentScene");
        //PlayerPrefs.DeleteKey("maxScene");
        //PlayerPrefs.DeleteKey("tempScene");

    }
}
