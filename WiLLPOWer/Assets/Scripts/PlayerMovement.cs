using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private float movement;

    private float waitTime;
    private bool canJump;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        waitTime = 1.25f;
        canJump = true;
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
    }

    IEnumerator UpMovement()
    {
        rb.velocity = new Vector3(0,movement,movement);
        canJump = false;
        yield return new WaitForSeconds(waitTime);
        canJump = true;

    }

    IEnumerator RightMovement()
    {
        rb.velocity = new Vector3(movement,movement,0);
        canJump = false;
        yield return new WaitForSeconds(waitTime);
        canJump = true;
    }

    IEnumerator DownMovement()
    {
        rb.velocity = new Vector3(0,movement,-movement);
        canJump = false;
        yield return new WaitForSeconds(waitTime);
        canJump = true;
    }

    IEnumerator LeftMovement()
    {
        rb.velocity = new Vector3(-movement,movement,0);
        canJump = false;
        yield return new WaitForSeconds(waitTime);
        canJump = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        transform.position = new Vector3(collision.gameObject.transform.position.x, transform.position.y,collision.gameObject.transform.position.z);
    }
}
