using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabFront : MonoBehaviour
{
    public bool isGrabbing = false;
    private MeshRenderer meshRenderer;

    void Start() {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    //on trigger enter
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "LeftHandSphere")
        {
            isGrabbing = true;
            meshRenderer.enabled = false;
        }
    }

    //on trigger exit
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "LeftHandSphere")
        {
            isGrabbing = false;
            meshRenderer.enabled = true;
        }
    }
}
