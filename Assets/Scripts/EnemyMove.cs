using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;


[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMove : MonoBehaviour, IEnemy
{
    private NavMeshAgent agent;
    private Animator animator;
    private float distance;
    public Transform target,bullspawn;
    public Transform parking;
    public bool meele;
    public int Health;
    public Rigidbody rb;
    public Vector3 direction;
    public GameObject bull;
    public bool death = false;
    public bool strelok = false;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        
       

    }
    private  void Update()
    {
       



        if (!death)
        {
            EnemyMovement();
        }
        if(Health <= 0)
        {
            death = true;
            gameObject.GetComponent<RagdollLogic>().Ragdoll(false);
            Destroy(animator);

            gameObject.GetComponent<RagdollLogic>().Colliders();
            rb.AddForce(Vector3.up , ForceMode.Impulse);
            
            Destroy(rb);
            Destroy(gameObject.GetComponent<EnemyMove>());

            
        }
    }
    public void EnemyMovement()
    {
        distance = Vector3.Distance(target.position, transform.position);
        if (distance > 40)
        {
            agent.SetDestination(parking.position);
            animator.SetTrigger("Idle");
        }

        if (distance > 35 && distance <= 40 && strelok)
        {
            agent.enabled = true;
            agent.SetDestination(target.position);
            animator.SetTrigger("Run");
        }
        if (distance <= 35 && distance > 5)
        {
            agent.enabled = true;
            agent.SetDestination(target.position);
            animator.SetTrigger("Run");
        }

        if (distance <= 35 && distance > 1.5f && strelok)
        {
            agent.enabled = false;
            var p = target.position;
            p.y = transform.position.y;
            bullspawn.LookAt(target);
            transform.LookAt(p);
            animator.SetTrigger("Shoot");
        }

        if (distance <= 3 && distance > 1.5f && strelok == false)
        {
            agent.enabled = true;
            agent.SetDestination(target.position);
            animator.SetTrigger("Attack");
        }

    }
    public void Hit()
    {
        if (distance <= 3 && distance > 1.5f)
        {
            target.gameObject.GetComponent<Character>().Lose();
        }
    }
    public  void Shoot()
    {
        
        
        GameObject newBull = Instantiate(bull, new  Vector3(bullspawn.position.x, bullspawn.position.y, bullspawn.position.z), transform.rotation.normalized);
        newBull.GetComponent<Rigidbody>().AddForce(bullspawn.forward * 10f,ForceMode.Impulse);
    }
    public void Damage(int damage)
    {
        
        Health -= damage;
    }
}
