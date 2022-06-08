using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb; 
    private float initializationTime;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        initializationTime = Time.timeSinceLevelLoad;
    }
    void Update()
    {
        float timeSinceInitialization = Time.timeSinceLevelLoad - initializationTime;

        rb.velocity = transform.TransformDirection(new Vector3(-6f, 0, 0));
        if (timeSinceInitialization > 4){
            Destroy(gameObject);
        }
        transform.position += new Vector3(-0 * Time.deltaTime, 0 , 0);
    }

    private void OnCollisionEnter(Collision other) {
        Destroy(gameObject);
    }
}
