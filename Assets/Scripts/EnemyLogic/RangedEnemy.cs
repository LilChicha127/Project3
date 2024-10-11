using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
    //public Transform bulletSpawn;
    public GameObject bullet;

    public float attackDistance;

    protected override void EnemyMovement()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        
        if (distance <= attackDistance )
        {
            agent.transform.LookAt(target.position);
            Attack();
        }
        else if(distance > 5) 
        {
            agent.SetDestination(target.position);
            animator.SetTrigger("Run");
        }
        else
        {
            animator.SetTrigger("Idle");
        }
    }

    private void Attack()
    {
        animator.SetTrigger("Shoot");
        
    }

    public void Shoot()
    {
        Vector3 bullspawn = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        
        GameObject newBullet = Instantiate(bullet, bullspawn, Quaternion.identity);
        newBullet.transform.LookAt(target.position);
        newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * 10f, ForceMode.Impulse);
    }
}
