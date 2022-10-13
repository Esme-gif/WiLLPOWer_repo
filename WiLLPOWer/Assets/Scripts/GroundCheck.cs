using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField]
    private GameObject dustCloud;
    
    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Vector3 dustPosiiton = new Vector3(transform.position.x, transform.position.y + 0.35f, transform.position.z);
            Instantiate(dustCloud, dustPosiiton, dustCloud.transform.rotation);
        }
    }

}
