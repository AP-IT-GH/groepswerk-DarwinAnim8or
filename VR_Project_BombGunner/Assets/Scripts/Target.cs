using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float maxLeftPosition;
    public float maxRightPosition;
    private int speed = 5;
    private int direction = 1;

    // Update is called once per frame
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
