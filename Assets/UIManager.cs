using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public string gameMode;
    GameObject[] pauseObjects;
    GameObject[] finishObjects;
    GameObject[] mapObjects;
    GameObject player;
    public GameObject playerCamera;
    
    private GameObject scoreText;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        finishObjects = GameObject.FindGameObjectsWithTag("ShowOnFinish");
        mapObjects = GameObject.FindGameObjectsWithTag("ShowOnMap");
        hidePaused();
        hideFinished();
        hideMap();

        

        if(SceneManager.GetActiveScene().name == "DiskFight")
        {
            player = GameObject.FindGameObjectWithTag("Player");
            gameMode = "disks";
        }
        if (SceneManager.GetActiveScene().name == "LightBikeFight")
        {
            player = GameObject.FindGameObjectWithTag("Player");
            gameMode = "bikes";
        } if (SceneManager.GetActiveScene().name == "City")
        {
            player = GameObject.FindGameObjectWithTag("Player");
            gameMode = "city";
        }
    }

    // Update is called once per frame
    void Update()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(Time.timeScale == 1)
            {
                Debug.Log("paused");
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                Debug.Log("paused 2");
                showPaused();
            } else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                hidePaused();
            }
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            if (Time.timeScale == 1)
            {
                
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                
                showMap();
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                hideMap();
            }
        }

        if (Time.timeScale == 0 && player.GetComponent<PlayerHealth>().alive == false)
        {
            Cursor.lockState = CursorLockMode.None;
            showFinished();
        }
        
    }

    public void showFinished()
    {
        foreach (GameObject g in finishObjects)
        {
            g.SetActive(true);
        }
        if (gameMode == "bikes")
        {
            scoreText = GameObject.Find("ScoreText");

            if (player.GetComponent<PlayerHealth>().alive == true)
            {
                scoreText.GetComponent<Text>().text = "You Won";
            } else
            {
                scoreText.GetComponent<Text>().text = "You Lost";
            }
            
        } else
        {
            scoreText = GameObject.Find("ScoreText");
            scoreText.GetComponent<Text>().text = "Score: " + player.GetComponent<PlayerScore>().score;
        }

    }

    public void showMap()
    {
        foreach (GameObject g in mapObjects)
        {
            g.SetActive(true);
            if (g.name == "Player Pin Object")
            {
                g.transform.position = new Vector3(100, 100, 100);
            }
        }
        playerCamera.SetActive(false);
        //Debug.Log(player.name);
        //GameObject.Find("Player Pin").GetComponent<RectTransform>().anchoredPosition = new Vector3(player.transform.position.x, player.transform.position.z, 0);
        //GameObject.Find("Player Pin Object").transform.position = player.transform.position;
        
        
    }

    public void setToLost(bool result)
    {
        player.GetComponent<PlayerHealth>().alive = result;
    }

    public void hideFinished()
    {
        foreach (GameObject g in finishObjects)
        {
            g.SetActive(false);
        }
    }

    public void hideMap()
    {
        foreach (GameObject g in mapObjects)
        {
            g.SetActive(false);
        }
        playerCamera.SetActive(true);
    }

    public void pauseControl()
    {

        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            showPaused();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            hidePaused();
        }
    }

    public void showPaused()
    {
        Debug.Log("paused 3");
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }

    public void hidePaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void LoadLevel(string level)
    {
        
        SceneManager.LoadScene(level);
    }

}
