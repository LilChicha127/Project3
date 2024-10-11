using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    public float attackDistance;
    public float detectionDistance;

    protected override void EnemyMovement()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= detectionDistance)
        {
            if (distance > attackDistance)
            {
                agent.SetDestination(target.position);
                animator.SetTrigger("Run");
            }
            else
            {
                // Выполняем атаки с ближним боем
                Attack();
            }
        }
    }

    private void Attack()
    {
        animator.SetTrigger("Attack");

        
    }
    public void Hit()
    {
        
            target.gameObject.GetComponent<Character>().Lose();
        
    }
}
