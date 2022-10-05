using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject startPosition;
    public GameObject endPosition;

    public PlayerMovement playerRef;



    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("player"))
        {
            playerRef = GameObject.Find("player").GetComponent<PlayerMovement>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
