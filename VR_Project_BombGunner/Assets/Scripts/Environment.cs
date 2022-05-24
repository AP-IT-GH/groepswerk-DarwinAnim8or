using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    public GameObject targetPrefab;

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("Target") == null){
            GameObject target = (GameObject)Instantiate(targetPrefab);
        }
    }
}
