using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public GameObject scoreDisplay;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {   
        if (GameObject.Find("PlayerUI").GetComponentInChildren<UIManager>().gameMode == "disks")
        {
            scoreDisplay.GetComponent<TextMesh>().text = score.ToString();
        }
        
    }
}
