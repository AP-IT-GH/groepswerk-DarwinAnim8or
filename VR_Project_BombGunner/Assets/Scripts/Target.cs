using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float maxLeftPosition;
    public float maxRightPosition;
    private float speed;
    private int direction = 1;

    void Start() {
        speed = Random.Range(2.0f, 6.0f);
    }

    void Update()
    {
        if ((transform.position.z > maxRightPosition) || (transform.position.z < maxLeftPosition)){
            direction = direction * -1;
        }
        transform.position = transform.position + new Vector3(0, 0, (direction * speed) * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Bullet"){
            Destroy(gameObject);
        }
    }
}
