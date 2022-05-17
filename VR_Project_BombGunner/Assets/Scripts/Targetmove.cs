using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targetmove : MonoBehaviour
{
    [SerializeField]
    Transform[] waypoints;
    int currentwaypoint = 0;
    Rigidbody rb;
    [SerializeField]
    float movespeed = 5;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if(Vector3.Distance(transform.position, waypoints[currentwaypoint].position) < .25f)
        {
            currentwaypoint += 1;
            currentwaypoint %= waypoints.Length;
        }
        Vector3 direction = (waypoints[currentwaypoint].position - transform.position).normalized;
        rb.MovePosition(transform.position + movespeed * Time.deltaTime * direction);
    }

        private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Bullet"){
            Destroy(gameObject);
        }
    }
}