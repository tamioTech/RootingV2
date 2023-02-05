using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundColour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GetComponent<MeshRenderer>().material.color = Color.red;
    }
}
