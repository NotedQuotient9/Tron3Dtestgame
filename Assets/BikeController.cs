using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeController : MonoBehaviour
{

    public static int moveSpeed = 60;
    public Vector3 bikeForward = Vector3.forward;

    public bool turnLeft;
    public bool turnRight;

    public GameObject bikeCameraObject;
    public GameObject player;
    public GameObject playerCamera;
    public GameObject explosion;
    GameObject e;

    public bool start;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        start = false;
        bikeCameraObject = Instantiate(bikeCameraObject) as GameObject;
        
        bikeCameraObject.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 2, this.transform.position.z);

        bikeCameraObject.GetComponent<BikeCameraController>().player = this.gameObject;
        
        e = Instantiate(explosion) as GameObject;
        e.transform.position = transform.position;

        StartCoroutine(destroyExplosion());

    }

    IEnumerator destroyExplosion()
    {
        yield return new WaitForSeconds(1f);
        if (e)
        {

            Destroy(e);
        }
    }

    // Update is called once per frame
    void Update()
    {
        turnRight = false;
        turnLeft = false;
        if (Input.GetKeyDown(KeyCode.E) && start == false)
        {
            Debug.Log("bike start");
            start = true;
        } else if (Input.GetKeyDown(KeyCode.E) && start == true)
        {
            Debug.Log("bike stop");
            start = false;
        }
        if (start)
        {
            this.transform.Translate(bikeForward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.D) && start)
        {
            turnRight = true;
            //this.transform.Rotate(Time.deltaTime * 0, 90, 0);
            this.transform.Rotate(0, 90, 0);

        }
        if (Input.GetKeyDown(KeyCode.A) && start)
        {
            turnLeft = true;
            this.transform.Rotate(0, 270, 0);
       }

        if (Input.GetKeyDown(KeyCode.Q) && !start)
        {

            player.SetActive(true);
            player.transform.position = transform.position;
            playerCamera.SetActive(true);

            Destroy(bikeCameraObject);
            Destroy(this.gameObject);
        }
    }

    public void getParams(GameObject passedPlayer, GameObject passedPlayerCamera)
    {
        this.player = passedPlayer;
        this.playerCamera = passedPlayerCamera;
    }
}
