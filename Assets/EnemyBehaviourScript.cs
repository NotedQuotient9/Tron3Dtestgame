using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]

public class EnemyBehaviourScript : MonoBehaviour
{

    public int health = 20;

    public GameObject handDisk;

    bool diskThrown;
    
    public GameObject disk;

    public float attackDistance = 3f;
    public float movementSpeed = 4f;

    //[HideInInspector]
    //public Transform playerTransform;

    public GameObject playerToAttack;

    NavMeshAgent agent;
    
    Rigidbody r;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
       
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = attackDistance;
        agent.speed = movementSpeed;
        r = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //agent.destination = playerToAttack.transform.position;

            // set movement animation for enemy
            // enemy speed animation set to half of movement speed
            anim.SetFloat("Speed", agent.velocity.magnitude * 1/2);

            // enemy destination set to player position
            agent.destination = playerToAttack.transform.position;

        // stops enemy from moving if they get too close to the player
        if (agent.remainingDistance < 0.5f)
        {
            agent.isStopped = true;
            
        } else
        {
            agent.isStopped = false;
        }

        //enemy set to look at player position
        transform.LookAt(new Vector3(playerToAttack.transform.position.x, transform.position.y, playerToAttack.transform.position.z));

        // if enemy stops moving, throw disk at player
        if (agent.velocity.magnitude == 0 && diskThrown == false)
        {
            diskThrown = true;
            GameObject clone;
            clone = Instantiate(disk, new Vector3(transform.position.x, transform.position.y + 1 / 2, transform.position.z), transform.rotation) as GameObject;
            if (clone)
            {
                
                // if object creation was successful then send params to enemy disk,
                // params are which enemy to return to, and that enemies disk
                clone.GetComponent<enemyDisk>().recieveParams(this.gameObject, handDisk);
            }
            // calls a co routine that waits until old disk is back before throwing new one
            StartCoroutine(WaitForDisk());
        }

        
    }

    IEnumerator WaitForDisk()
    {
        
        //wait an amount for new disk is allowed to be thrown
        yield return new WaitForSeconds(6);

        diskThrown = false;
    }

}

