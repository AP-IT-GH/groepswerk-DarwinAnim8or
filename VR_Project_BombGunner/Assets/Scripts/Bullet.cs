using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb; 

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        rb.velocity = new Vector3(-30, 0, 0);
        //transform.position += new Vector3(-0 * Time.deltaTime, 0 , 0);
    }

    private void OnCollisionEnter(Collision other) {
        Destroy(gameObject);
    }
}
