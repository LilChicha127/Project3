using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class Guns : MonoBehaviour, IWeapon
{

    public GameObject ammoGO;

    public Animator animator;
    public Transform dulo;
    public bool auto;
    private Transform _cam;
    public bool pistol = true;
    public int bullets { get; set; }
    public AudioSource sound3,sound0;
    private void Start()
    {
        
        _cam = FindAnyObjectByType<CameraMovement>().transform;
        bullets = gameObject.GetComponent<Item>().Bullets;
        if (pistol)
            dulo = GameObject.Find("dulo").transform;
        else
        {
            dulo = GameObject.Find("duloShotgun").transform;
        }
        sound3 = FindAnyObjectByType<SoundLogic>().sounds[3];
        sound0 = FindAnyObjectByType<SoundLogic>().sounds[0];
    }
    public void Attack()
    {
        if (bullets > 0)
        {
            animator.SetTrigger("Attack");
        }
        
    }
    public async void Damage()
    {
        

        bullets -= 1;
        GameObject ammoGo = Instantiate(ammoGO, new Vector3(dulo.position.x, dulo.position.y, dulo.position.z), _cam.rotation.normalized);
        ammoGo.GetComponent<Rigidbody>().AddForce(_cam.forward * 50f, ForceMode.Impulse);

        if (pistol)
        {
            sound3.Play();
        }
        else
        {
            sound0.Play();
        }
        await Task.Delay(2000);
        if(ammoGO != null)
        Destroy(ammoGo);
        
        
    }
    
    
}
