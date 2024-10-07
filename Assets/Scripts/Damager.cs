using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            if (other.GetComponentInParent<EnemyMove>() != null)
            {
                other.GetComponentInParent<EnemyMove>().Damage(damage);
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            
        }
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Character>().Lose();
        }
        else  if (other){ Destroy(gameObject); }
    }


}
