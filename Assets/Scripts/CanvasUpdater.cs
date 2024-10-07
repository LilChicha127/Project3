using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CanvasUpdater : MonoBehaviour, ICanvas
{

    public Character character;

    public TextMeshProUGUI txtBullets;
    private Guns guns;

    private void Start()
    {
        guns = FindAnyObjectByType<Guns>();
    }
    public void bullUpdate()
    {
        if (guns != null)
        {
            txtBullets.text = guns.bullets.ToString();
        }
        else
        {
            txtBullets.text = "";
        }
    }
    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }



}
