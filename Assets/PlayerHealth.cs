using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public GameObject handDisk;
    public GameObject backDisk;
    public bool alive;
    public int health = 100;
    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 100)
        {
            handDisk.GetComponent<Renderer>().material.color = Color.white;
            backDisk.GetComponent<Renderer>().material.color = Color.white;
        } else if (health == 80)
        {
            handDisk.GetComponent<Renderer>().material.color = Color.grey;
            backDisk.GetComponent<Renderer>().material.color = Color.grey;
        }
        else if (health == 60)
        {
            handDisk.GetComponent<Renderer>().material.color = Color.yellow;
            backDisk.GetComponent<Renderer>().material.color = Color.yellow;
        }
        else if (health == 40)
        {
            handDisk.GetComponent<Renderer>().material.color = Color.red;
            backDisk.GetComponent<Renderer>().material.color = Color.red;
        }
        else if (health == 20)
        {
            handDisk.GetComponent<Renderer>().material.color = Color.black;
            backDisk.GetComponent<Renderer>().material.color = Color.black;
        } else if (health == 0)
        {
            alive = false;
        }

    }
}
