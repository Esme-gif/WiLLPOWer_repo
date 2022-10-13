using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 offset;

    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
    }

    // delayed Update 
    void LateUpdate()
    {
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, offset.z + target.position.z);
        //Linearly interpolates between two points.
        //Interpolates between the points a and b by the interpolant t. 
        //The parameter t is clamped to the range [0, 1]. 
        //This is most commonly used to find a point some fraction of the way along a line between two endpoints (e.g. to move an object gradually between those points).
        transform.position = Vector3.Lerp(transform.position, newPosition, 10 * Time.deltaTime);
    }
}
