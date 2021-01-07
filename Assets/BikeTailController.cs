using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeTailController : MonoBehaviour
{
    //public GameObject bike;
    public GameObject tail;
    bool extend;
    bool turnRight;
    bool turnLeft;
    float yRotate = 0;
    Vector3 turnVector;
    public GameObject tailSegmentParent;
    // Start is called before the first frame update
    void Start()
    {
        extend = false;
        tailSegmentParent = new GameObject();
        tailSegmentParent.name = "Bike Tail";
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (extend == true)
            {
                extend = false;
            } else
            {
                extend = true;
            }
        }
        //extend = GetComponentInParent<BikeController>().start;
        turnRight = GetComponentInParent<BikeController>().turnRight;
        turnLeft = GetComponentInParent<BikeController>().turnLeft;

        

        

        if (turnLeft)
        {
            Debug.Log("left turn made");
            yRotate = yRotate - 90f;
            
        }
        else if (turnRight)
        {
            yRotate = yRotate + 90f;
        } else
        {
            turnVector = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
        if (extend)
        {
            GameObject tailSegment;
            tailSegment = Instantiate(tail) as GameObject;
            tailSegment.transform.position = turnVector;
            tailSegment.transform.Rotate(0, yRotate, 0);
            tailSegment.transform.parent = tailSegmentParent.transform;
            //this.transform.position = new Vector3(transform.position.x, transform.position.y, bike.transform.position.z -2);
            //this.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z + 2f);
        }
    }
}
