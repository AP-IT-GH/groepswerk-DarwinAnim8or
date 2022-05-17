using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Bullet bulletPrefab;
    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown("space")){
            Bullet bullet = Instantiate(bulletPrefab);
            bullet.transform.parent = GameObject.Find("Gun").transform;
            bullet.transform.localPosition = new Vector3(0f, 0f, 0f);
            bullet.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
            Debug.Log(GameObject.Find("Gun").transform);
      }  
    }
}
