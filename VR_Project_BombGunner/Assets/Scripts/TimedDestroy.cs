using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestroy : MonoBehaviour
{
    public float timeToDestroy = 1.0f;

    void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }
}
