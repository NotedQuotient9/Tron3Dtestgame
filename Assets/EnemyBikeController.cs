using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBikeController : MonoBehaviour
{
    public static int moveSpeed = 60;
    public Vector3 bikeForward = Vector3.forward;
    public GameObject tail;
    Vector3 positionBehindBike;
    float yRotate = 0f;
    float smartTurnRight;
    float smartTurnLeft;


    public GameObject tailSegmentParent;
    private void Start()
    {
        tailSegmentParent = new GameObject();
        tailSegmentParent.name = "Enemy Bike Tail";
        
        
    }

    private void Update()
    {
        positionBehindBike = transform.position - transform.forward;
        this.transform.Translate(bikeForward * moveSpeed * Time.deltaTime);

        GameObject tailSegment;
        tailSegment = Instantiate(tail) as GameObject;
        tailSegment.transform.position = positionBehindBike;
        tailSegment.transform.Rotate(0, yRotate, 0);
        tailSegment.transform.parent = tailSegmentParent.transform;

        //StartCoroutine(timedTurn());

    }

    //IEnumerator timedTurn()
    //{
        
    //    yield return new WaitForSeconds(10f);

    //    Debug.Log("timedTurn");
    //    doRandomTurn();
    //}

    private void FixedUpdate()
    {

        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Vector3 right = transform.TransformDirection(Vector3.right);
        Vector3 left = transform.TransformDirection(Vector3.left);
        RaycastHit hit;

        // turning works by checking what the distance to the nearest walls on the left and right are
        // and then turning in the direction with the farthest wall
        // if the distance of both is the same, then it chooses a direction to turn at random
        // i call it smart turning, cause i'm well cool
        if (Physics.Raycast(transform.position + transform.forward, right, out hit))
        {
            smartTurnRight = hit.distance;   
        }

        if (Physics.Raycast(transform.position + transform.forward, left, out hit))
        {
            smartTurnLeft = hit.distance;
        }



        //if (Physics.Raycast(transform.position + transform.forward, forward, 10))
        if (Physics.SphereCast(transform.position + transform.forward, 5f, forward,out hit, 10))
        {
            

            if (smartTurnRight > smartTurnLeft)
            {
                turnRight();
            } else if (smartTurnLeft > smartTurnRight)
            {
                turnLeft();
            } else
            {
                doRandomTurn();
            }
            

        }

    }

    void doRandomTurn()
    {
        int leftOrRight = Random.Range(0, 2);

        if (leftOrRight == 0)
        {
            Debug.Log("Right");
            turnRight();
        }
        else
        {
            Debug.Log("Left");
            turnLeft();
        }
    }

    void turnRight()
    {
        this.transform.Rotate(0, 90, 0);
        yRotate = yRotate + 90f;
    }

    void turnLeft()
    {
        this.transform.Rotate(0, 270, 0);
        yRotate = yRotate - 90f;
    }

}
