using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        //Destroy(other.gameObject);
        Time.timeScale = 0;
        other.GetComponent<PlayerHealth>().alive = false;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
