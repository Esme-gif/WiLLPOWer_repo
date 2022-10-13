using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // particle initialization
    void Start()
    {
        Destroy(gameObject, 1f);
    }
}
