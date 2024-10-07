using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Granade : MonoBehaviour
{
    public float Radius;
    public float Force;
    public GameObject explEffect;
   // public AudioSource explAudio;
    public void Explode()
    {
        FindAnyObjectByType<SoundLogic>().sounds[4].Play();
        Collider[] overlappedGO = Physics.OverlapSphere(transform.position, Radius);
        
        for (int i = 0; i < overlappedGO.Length; i++)
        {
            Rigidbody rb = overlappedGO[i].attachedRigidbody;
            if (rb && rb.gameObject.GetComponentInParent<EnemyMove>() != null)
            {
                rb.gameObject.GetComponentInParent<EnemyMove>().Damage(100);
                rb.GetComponentInParent<Rigidbody>().isKinematic = false;
                rb.GetComponentInParent<Rigidbody>().AddExplosionForce(Force, transform.position, Radius);

            }
        }
        Destroy(gameObject);
        Instantiate(explEffect,transform.position,Quaternion.identity);
    }

    public void Throw(Vector3 player,Quaternion rotat)
    {
        FindAnyObjectByType<SoundLogic>().sounds[5].Play();
        GameObject grenade = Instantiate(gameObject,player,rotat.normalized);
        grenade.GetComponent<Rigidbody>().isKinematic = false;
        grenade.GetComponent<Rigidbody>().AddForce(FindAnyObjectByType<CameraMovement>().transform.forward * 50,ForceMode.Impulse);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(Tempik.indexThrowableWeapon == 0)
        Explode();
        else if (Tempik.indexThrowableWeapon == 1 && collision.collider.CompareTag("enemy") && collision.gameObject.GetComponentInParent<EnemyMove>() != null)
        {
            collision.gameObject.GetComponentInParent<EnemyMove>().Damage(100);
            
        }
        else if (Tempik.indexThrowableWeapon == 1 )
        {
            Destroy(gameObject);
        }
    }

}
