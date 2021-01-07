using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private int playerScore;
    public GameObject enemyToSpawn;
    public float timeBetweenSpawns;
    bool canSpawn;
    public GameObject playerToAttack;
    bool exploded = false;

    GameObject[] explosions;



        // Start is called before the first frame update
        void Start()
    {
        canSpawn = false;
        timeBetweenSpawns = 50f;
        playerScore = playerToAttack.GetComponent<PlayerScore>().score;
        StartCoroutine(checkCanBeginSpawning());
    }

    // the spawners only start when the player has killed one enemy, so this method waits until that has happened
    IEnumerator checkCanBeginSpawning()
    {

        
        while (playerScore < 1)
        {
            yield return null;
        }

        canSpawn = true;
    }


    // Update is called once per frame
    void Update()
    {
        playerScore = playerToAttack.GetComponent<PlayerScore>().score;

        if (playerScore >= 5)
        {
            timeBetweenSpawns = 35f;
        } else if (playerScore >= 9)
        {
            timeBetweenSpawns = 20f;
        }

        if (canSpawn)
        {
            GameObject clone;
            clone = Instantiate(enemyToSpawn, new Vector3(transform.position.x, transform.position.y - 10, transform.position.z), transform.rotation) as GameObject;
            clone.GetComponent<EnemyBehaviourScript>().playerToAttack = playerToAttack;
            canSpawn = false;
            StartCoroutine(waitForNextSpawn());
        }

        // code that cleans up unwanted explosion objects, it checks for them every 4 seconds using a coroutine
        explosions = GameObject.FindGameObjectsWithTag("Explosion");

        foreach (GameObject explosion in explosions)
        {
            StartCoroutine(waitForExplode());
            if (exploded)
            {
                Destroy(explosion);
                exploded = false;
            }

        }

    }

    IEnumerator waitForExplode()
    {
        yield return new WaitForSeconds(4f);
        exploded = true;
    }

    IEnumerator waitForNextSpawn()
    {

        yield return new WaitForSeconds(timeBetweenSpawns);
        canSpawn = true;

    }
}
