using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private float movement;

    private GameManager gameManager;

    private float waitTime;
    private float positionCool;
    private int outOfBound;
    private bool canJump;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        waitTime = 1f;
        positionCool = 0.25f;
        outOfBound = -7;
        canJump = true;

        if (GameObject.Find("GameManager"))
        {
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canJump)
        {
            if (Input.GetKeyDown("up"))
            {
                //rb.velocity = new Vector3(0,movement,movement);
                StartCoroutine(UpMovement());
            }
            if (Input.GetKeyDown("right"))
            {
                //rb.velocity = new Vector3(movement,movement,0);
                StartCoroutine(RightMovement());
            }
            if (Input.GetKeyDown("down"))
            {
                //rb.velocity = new Vector3(0,movement,-movement);
                StartCoroutine(DownMovement());
            }
            if (Input.GetKeyDown("left"))
            {
                //rb.velocity = new Vector3(-movement,movement,0);
                StartCoroutine(LeftMovement());
            }
        }
        if (transform.position.y <= outOfBound)
        {
            RePosition();
        }
    }

    IEnumerator UpMovement()
    {
        rb.velocity = new Vector3(0,movement,movement);
        DisableMovement();
        yield return new WaitForSeconds(waitTime);
        EnableMovement();

    }

    IEnumerator RightMovement()
    {
        rb.velocity = new Vector3(movement,movement,0);
        DisableMovement();
        yield return new WaitForSeconds(waitTime);
        EnableMovement();
    }

    IEnumerator DownMovement()
    {
        rb.velocity = new Vector3(0,movement,-movement);
        DisableMovement();
        yield return new WaitForSeconds(waitTime);
        EnableMovement();
    }

    IEnumerator LeftMovement()
    {
        rb.velocity = new Vector3(-movement,movement,0);
        DisableMovement();
        yield return new WaitForSeconds(waitTime);
        EnableMovement();
    }

    void OnCollisionEnter(Collision collision)
    {
        transform.position = new Vector3(collision.gameObject.transform.position.x, transform.position.y,collision.gameObject.transform.position.z);
    }

    public void DisableMovement()
    {
        canJump = false;
    }

    public void EnableMovement()
    {
        canJump = true;
    }

    public void RePosition()
    {
        StartCoroutine(MovePlayer());
    }

    IEnumerator MovePlayer()
    {
        //disable and then enable player movement after putting player in start position
        DisableMovement();
        yield return new WaitForSeconds(positionCool);
        if (gameManager.startPosition != null)
        {
            transform.position = gameManager.startPosition.transform.position;
        }
        EnableMovement();
        
    }
}
