using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBike : MonoBehaviour
{
    
    public GameObject bike;
    public GameObject playerCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameObject newBike;
            newBike = Instantiate(bike) as GameObject;
            newBike.transform.position = transform.position;
            newBike.GetComponent<BikeController>().getParams(this.gameObject, playerCamera);
            playerCamera.SetActive(false);
            this.gameObject.SetActive(false);

        }
    }
}
