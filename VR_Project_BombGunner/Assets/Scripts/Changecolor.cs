using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changecolor : MonoBehaviour
{

    public Material mycolor;
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "bullet")
        {
            this.transform.GetComponent<Renderer>().material = mycolor;
        }
    }
}
