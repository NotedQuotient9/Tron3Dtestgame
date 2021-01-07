using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailObjectController : MonoBehaviour
{
    int bikesRemaining = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("something hit the tail: " + other.gameObject.tag);

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("hit player");
            Cursor.lockState = CursorLockMode.None;
            GameObject.Find("PlayerUI").GetComponentInChildren<UIManager>().setToLost(false);
            GameObject.Find("PlayerUI").GetComponentInChildren<UIManager>().showFinished();
            Time.timeScale = 0;


        } else if (other.gameObject.tag == "Arena")
        {

        } else
        {
            Destroy(other.gameObject);
            bikesRemaining = bikesRemaining - 1;
        }


        //if (other.gameObject.tag != "Arena")
        //{
        //    Destroy(other.gameObject);
        //} 
        //if (other.gameObject.tag != "Player")
        //{
        //    bikesRemaining = bikesRemaining - 1;
        //} else if (other.gameObject.tag == "Player")
        //{
            
        //}

        //Time.timeScale = 0;
        //checkForTail(other);

    }

    void checkForTail(Collider other)
    {
        //if (GameObject.Find("Bike Tail"))
        //{
        //    Destroy(GameObject.Find("Bike Tail"));
        //}

        if (other.gameObject.GetComponent<BikeController>().bikeCameraObject)
        {
            Destroy(other.gameObject.GetComponent<BikeController>().bikeCameraObject);
        }
        Debug.Log("something hit the tail");
        Destroy(other.gameObject);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bikesRemaining == 0)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            GameObject.Find("PlayerUI").GetComponentInChildren<UIManager>().showFinished();
        }   
    }
}
