using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Granade : MonoBehaviour
{
    public float Radius;
    public float Force;
    public GameObject explEffect;
    private AudioSource sound4,sound5;
   // public AudioSource explAudio;
   private void Start()
    {
        sound4 = FindAnyObjectByType<SoundLogic>().sounds[4];
        sound5 = FindAnyObjectByType<SoundLogic>().sounds[5];
    }
    public void Explode()
    {
        sound4.Play();
        Collider[] overlappedGO = Physics.OverlapSphere(transform.position, Radius);
        
        for (int i = 0; i < overlappedGO.Length; i++)
        {
            Rigidbody rb = overlappedGO[i].attachedRigidbody;
            if (rb && rb.gameObject.GetComponentInParent<Enemy>() != null)
            {
                rb.gameObject.GetComponentInParent<Enemy>().TakeDamage(100);
                rb.GetComponentInParent<Rigidbody>().isKinematic = false;
                rb.GetComponentInParent<Rigidbody>().AddExplosionForce(Force, transform.position, Radius);

            }
        }
        Destroy(gameObject);
        Instantiate(explEffect,transform.position,Quaternion.identity);
    }

    public void Throw(Vector3 player,Quaternion rotat)
    {
        sound5.Play();
        GameObject grenade = Instantiate(gameObject,player,rotat.normalized);
        grenade.GetComponent<Rigidbody>().isKinematic = false;
        grenade.GetComponent<Rigidbody>().AddForce(FindAnyObjectByType<CameraMovement>().transform.forward * 50,ForceMode.Impulse);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(Tempik.indexThrowableWeapon == 0)
        Explode();
        else if (Tempik.indexThrowableWeapon == 1 && collision.collider.CompareTag("enemy") && collision.gameObject.GetComponentInParent<Enemy>() != null)
        {
            collision.gameObject.GetComponentInParent<Enemy>().TakeDamage(100);
            
        }
        else if (Tempik.indexThrowableWeapon == 1 )
        {
            Destroy(gameObject);
        }
    }

}
