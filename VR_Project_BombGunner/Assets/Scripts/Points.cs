using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    public int Score = 0;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Score++;
            Debug.Log("score:" + Score);
            Destroy(collision.gameObject);
        }
    }
}
