using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    [Header("Colors")]
    [SerializeField] private Material _OGColor;
    [SerializeField] private Material _TriggerColor; // might make its own script
    [SerializeField] private Material _PositionColor;

    private GameManager gameManager;
    private PlayerMovement playerRef;

    //private float coolTime;

    [Header("Is Something?")]
    public bool isTrap;
    public bool isStart;
    public bool isEnd;
    

    Renderer rend;


    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("GameManager"))
        {
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        }
        if (GameObject.Find("player"))
        {
            playerRef = GameObject.Find("player").GetComponent<PlayerMovement>();
        }

        //coolTime = 0.25f;
        rend = this.GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = _OGColor;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (isTrap)
            {
                rend.sharedMaterial = _TriggerColor;
                //StartCoroutine(RePosition(collision.gameObject));
                playerRef.RePosition();
            }
            else
            {
                rend.sharedMaterial = _PositionColor;
            }
        }
    }


    void OnCollisionExit(Collision collisionInfo)
    {
        // it works Debug.Log("left the trap");
        if (!isTrap)
        {
            rend.sharedMaterial = _OGColor;
        }
    }
/*
    IEnumerator RePosition(GameObject playerObject)
    {
        //disable and then enable player movement after some time
        playerRef.DisableMovement();
        yield return new WaitForSeconds(coolTime);
        if (gameManager.startPosition != null)
        {
            playerObject.transform.position = gameManager.startPosition.transform.position;
        }
        playerRef.EnableMovement();
        // move player to starting point
        //collision.gameObject.transform.position = new Vector3(5,2,0);

    }
    */


}
