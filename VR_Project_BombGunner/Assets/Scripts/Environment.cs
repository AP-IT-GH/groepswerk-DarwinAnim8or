using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    public Target targetPrefab;

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("Target") == null){
            Target target = Instantiate(targetPrefab);
            Debug.Log("spawn");
        }
    }
}
