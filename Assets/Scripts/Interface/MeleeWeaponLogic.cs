using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class MeleeWeaponLogic : MonoBehaviour, IWeapon
{
    public Animator anim;
    private AudioSource sound5,sound1;
    private void Start()
    {
        sound5 = FindAnyObjectByType<SoundLogic>().sounds[5];
        sound1 = FindAnyObjectByType<SoundLogic>().sounds[1];
    }
    public  void Attack()
    { 
       
        anim.SetTrigger("_Attack");
        sound5.Play();

    }
    public void Damage()
    {
        
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        if(Physics.Raycast(ray, out hit, 10f) && hit.collider.CompareTag("enemy"))
        {
            sound1.Play();
            hit.collider.gameObject.GetComponentInParent<Enemy>().TakeDamage(100);
            //
        }
    }
}
