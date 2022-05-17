using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    public Targetmove targetPrefab;

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("Target") == null){
            Targetmove target = Instantiate(targetPrefab);
            Debug.Log("spawn");
        }
    }
}
