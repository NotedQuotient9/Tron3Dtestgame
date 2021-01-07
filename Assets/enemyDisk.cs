using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDisk : MonoBehaviour
{


    bool go;  

    GameObject enemy;
    GameObject disk;

    public GameObject explosion;
    private GameObject e;

    Transform itemToRotate;

    Vector3 locationInFrontOfEnemy;

    // Start is called before the first frame update
    void Start()
    {
        go = false;

        StartCoroutine(Throw());

    }

    // method to get params from enemy behaviour script, passes in the enemy throwing, and their handdisk
    public void recieveParams(GameObject passedEnemy, GameObject passedDisk)
    {


        go = false;
        enemy = passedEnemy;
        disk = passedDisk;
       
        // now that we have the disk and enemy, these variables can all be set
        disk.GetComponent<MeshRenderer>().enabled = false;

        itemToRotate = gameObject.transform.GetChild(0);

        locationInFrontOfEnemy = new Vector3(enemy.transform.position.x, enemy.transform.position.y + 1, enemy.transform.position.z) + enemy.transform.forward * 15f;
        
        //StartCoroutine(Throw());
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
        // only does something if it hit's the player
        if (other.tag == "Player")
        {

            //Debug.Log("Player hit");
            if (other.GetComponent<PlayerHealth>())
            {
                Debug.Log("health found");
                e = Instantiate(explosion) as GameObject;
                e.transform.position = transform.position;
                other.GetComponent<PlayerHealth>().health -= 10;

                if (other.GetComponent<PlayerHealth>().health <= 0)
                {
                    Debug.Log("Player Destroyed");
                    Time.timeScale = 0;
                    other.GetComponent<PlayerHealth>().alive = false;
                    //Destroy(other.gameObject);
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
            
            transform.position = Vector3.MoveTowards(transform.position, locationInFrontOfEnemy, Time.deltaTime * 15);

        }
        if (!go)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(enemy.transform.position.x, enemy.transform.position.y + 1 / 2, enemy.transform.position.z), Time.deltaTime * 5);

        }

        if (!go && Vector3.Distance(enemy.transform.position, transform.position) < 1.5)
        {
            disk.GetComponent<MeshRenderer>().enabled = true;
            Destroy(this.gameObject);
        }
    }
}
