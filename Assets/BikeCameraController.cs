using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeCameraController : MonoBehaviour
{


    
  
    Vector3 turnRight;
    bool rightTurn;
    bool bikeMoving;

    public GameObject player;        //Public variable to store a reference to the player game object


    private Vector3 offset;            //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {

        transform.position = player.transform.position + offset;
    }

    void Update()
    {
        bikeMoving = player.GetComponent<BikeController>().start;

        if (Input.GetKeyDown(KeyCode.D) && bikeMoving)
        {
            //    rightTurn = true;
            Debug.Log("turn right");
            
            this.transform.position = new Vector3(transform.position.x - 6, transform.position.y, transform.position.z + 6);
            this.transform.rotation = Quaternion.Euler(15, transform.rotation.eulerAngles.y + 90, 0);


        }

        if (Input.GetKeyDown(KeyCode.A) && bikeMoving)
        {
            //    rightTurn = true;
            Debug.Log("turn left");

            this.transform.position = new Vector3(transform.position.x + 6, transform.position.y, transform.position.z - 6);
            this.transform.rotation = Quaternion.Euler(15, transform.rotation.eulerAngles.y - 90, 0);

        }




    }


    }

