using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IinputController : MonoBehaviour
{

    private Character character;
    private MainMenu menu;



    public AllWeapons Allweapons;
    public List<ICloseWeapon> closeWeapon;
    public List<Granade> granade;
    public int gr = 3;
    private int speed = 5;
    public bool canInput = true;
    private void Awake()
    {
        closeWeapon = new List<ICloseWeapon>();
        Allweapons = FindAnyObjectByType<AllWeapons>();
    }
    public void Start()
    {
        character = FindAnyObjectByType<Character>();

        
        menu = FindAnyObjectByType<MainMenu>();

        


    }


    private void Update()       // не совсем все инкапсулированно но да
    {
        character.Move(speed);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu.OpenOrCloseMenu(true);
        }
        if (canInput)
        {
            if (Input.GetKeyDown(KeyCode.G) && gr > 0)
            {
                gr -= 1; if (Tempik.indexThrowableWeapon < 3)
                    granade[Tempik.indexThrowableWeapon].Throw(character.transform.position, character.transform.rotation);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                character.Jump(500);

            }


            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Allweapons.weapons[Tempik.chaseWeapon].GetComponent<ICloseWeapon>().Attack();
               

            }



        }
    }

    
}
