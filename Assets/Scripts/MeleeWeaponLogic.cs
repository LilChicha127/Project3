using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class MeleeWeaponLogic : MonoBehaviour, ICloseWeapon
{
    public Animator anim;
  
    public  void Attack()
    { 
       
        anim.SetTrigger("_Attack");
        FindAnyObjectByType<SoundLogic>().sounds[5].Play();

    }
    public void Damage()
    {
        
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        if(Physics.Raycast(ray, out hit, 10f) && hit.collider.CompareTag("enemy"))
        {
            FindAnyObjectByType<SoundLogic>().sounds[1].Play();
            hit.collider.gameObject.GetComponentInParent<EnemyMove>().Damage(100);
            //
        }
    }
}
