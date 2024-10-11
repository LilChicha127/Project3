using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    protected NavMeshAgent agent;
    protected Animator animator;
    public Transform target { get; set; }
    public bool death = false;
    public int health;

    protected virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        target = FindAnyObjectByType<Character>().transform;
    }

    protected virtual void Update()
    {
        if (!death)
        {
            
            EnemyMovement();
        }

        if (health <= 0)
        {
            HandleDeath();
        }
    }

    protected abstract void EnemyMovement();

    protected virtual void HandleDeath()
    {
        death = true;
        gameObject.GetComponent<RagdollLogic>().Ragdoll(false);
        Destroy(animator);
        gameObject.GetComponent<RagdollLogic>().Colliders();
        Destroy(GetComponent<NavMeshAgent>());
        Destroy(this);
    }

    public virtual void TakeDamage(int damage)
    {
        health -= damage;
    }
}
