using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LogicMainMenu : MonoBehaviour
{
    public List<GameObject> weaponButt,granadeButt,lvls;
    public GameObject startButt;
    private bool chaselvl = false;
    private void Awake()
    {
        Debug.Log("Awake");
    }


    private void Start()
    {
        Debug.Log("Start");
        Cursor.lockState = CursorLockMode.None;
        
    }
    private void Update()
    {
        WeaponUpd();
        lvlsUpd();
        GranadeUpd();
    
    }
    public void OpenStart()
    {
        startButt.GetComponent<Button>().interactable = true;
    }
    public void BackToLevels()
    {
        if((Tempik.tempScene + 1)<16)
        SceneManager.LoadScene(Tempik.tempScene+1);
        else
            SceneManager.LoadScene(15);

    }
    public void ChooseLevel(int numberLevel)
    {
        SceneManager.LoadScene(numberLevel+1);
    }
    public void ChooseWeapon(int numberWeapon)
    {
        chaselvl = true;
        Tempik.chaseWeapon = numberWeapon;
        weaponButt[numberWeapon].GetComponent<Image>().color = Color.green;
        for(int i = 0; i <= 3; i++)
        {
            if(i != numberWeapon)
            weaponButt[i].GetComponent<Image>().color = Color.white;
        }
    }
    public void Granade(int indGranade)
    {
        Tempik.indexThrowableWeapon = indGranade;
        granadeButt[indGranade].GetComponent<Image>().color = Color.green;
        for (int i = 0; i <= 1; i++)
        {
            if (i != indGranade)
                granadeButt[i].GetComponent<Image>().color = Color.white;
        }
    }
    public void WeaponUpd()
    {
        if(Tempik.tempScene > 1)
        {
            weaponButt[1].GetComponent<Button>().interactable = true;
        }
        if (Tempik.tempScene > 2)
        {
            weaponButt[2].GetComponent<Button>().interactable = true;
        }
        if (Tempik.tempScene > 5)
        {
            weaponButt[3].GetComponent<Button>().interactable = true;
        }
    }
    public void GranadeUpd()
    {
        if (Tempik.tempScene > 5)
        {
            granadeButt[0].GetComponent<Button>().interactable = true;
        }
        if (Tempik.tempScene > 9)
        {
            granadeButt[1].GetComponent<Button>().interactable = true;
        }
    }
    public void lvlsUpd()
    {
        if (chaselvl)
        {

            for (int i = 0; i < Tempik.tempScene; i++)
            {
                lvls[i].GetComponent<Button>().interactable = true;
            }
        }
        
    }
    public void buttClickSound()
    {
        FindAnyObjectByType<SoundLogic>().sounds[2].Play();
    }
}
