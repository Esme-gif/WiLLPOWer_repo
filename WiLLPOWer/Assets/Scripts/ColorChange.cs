using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    [Header("Colors")]
    [SerializeField] private Material _OGColor;
    [SerializeField] private Material _TriggerColor; // might make its own script
    [SerializeField] private Material _PositionColor;

    [Header("Is Trap?")]
    public bool isTrap;
    

    Renderer rend;


    // Start is called before the first frame update
    void Start()
    {
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
                // move player to starting point
                //collision.gameObject.transform.position = new Vector3(5,2,0);
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


}
