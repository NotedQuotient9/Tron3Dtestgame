using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disk : MonoBehaviour
{


    bool go;

    GameObject player;
    GameObject disk;
    public GameObject explosion;
    private GameObject e;

    int playerHealth;

    Transform itemToRotate;

    Vector3 locationInFrontOfPlayer;

    // Start is called before the first frame update
    void Start()
    {
        go = false;

        player = GameObject.Find("Player");
        disk = GameObject.Find("Disk");

        playerHealth = player.GetComponent<PlayerHealth>().health;

        //showHealth();

        disk.GetComponent<MeshRenderer>().enabled = false;

        itemToRotate = gameObject.transform.GetChild(0);

        locationInFrontOfPlayer = new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z) + player.transform.forward * 5f;

        StartCoroutine(Throw());

    }

    void showHealth()
    {
        //Debug.Log("health shown");
        if (playerHealth == 100)
        {
            //this.GetComponent<Renderer>().material.color = Color.white;
            itemToRotate.gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
        else if (playerHealth == 80)
        {
            //this.GetComponent<Renderer>().material.color = Color.grey;
            itemToRotate.gameObject.GetComponent<Renderer>().material.color = Color.grey;
        }
        else if (playerHealth == 60)
        {
            //this.GetComponent<Renderer>().material.color = Color.yellow;
            itemToRotate.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        }
        else if (playerHealth == 40)
        {
            //this.GetComponent<Renderer>().material.color = Color.red;
            itemToRotate.gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        else if (playerHealth == 20)
        {
            //this.GetComponent<Renderer>().material.color = Color.black;
            itemToRotate.gameObject.GetComponent<Renderer>().material.color = Color.black;
        }
    }


    IEnumerator Throw()
    {
        go = true;
        yield return new WaitForSeconds(1f);
        if (e)
        {
            
            Destroy(e);
        }
        go = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
        {
            if (other.GetComponent<EnemyBehaviourScript>())
            {
                e = Instantiate(explosion) as GameObject;
                e.transform.position = transform.position;
                
                other.GetComponent<EnemyBehaviourScript>().health -= 10;
               
                if (other.GetComponent<EnemyBehaviourScript>().health <= 0)
                {
                    
                    Destroy(other.gameObject);
                    player.GetComponent<PlayerScore>().score += 1;
                    Debug.Log("score == " + player.GetComponent<PlayerScore>().score);
                }
            }
            
        }
        
        
    }



    // Update is called once per frame
    void Update()
    {
        itemToRotate.transform.Rotate(0, Time.deltaTime * 500, 0);

        if (go)
        {
            transform.position = Vector3.MoveTowards(transform.position, locationInFrontOfPlayer, Time.deltaTime * 10);

        }
        if (!go)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, player.transform.position.y + 1/2, player.transform.position.z), Time.deltaTime * 10);

        }

        if (!go && Vector3.Distance(player.transform.position, transform.position) < 1.5 )
        {
            disk.GetComponent<MeshRenderer>().enabled = true;
            Destroy(this.gameObject);
        }
        showHealth();

    }
}
