using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 60.0f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.up * bulletSpeed);
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.other.gameObject);
        Destroy(this);
    }
}
