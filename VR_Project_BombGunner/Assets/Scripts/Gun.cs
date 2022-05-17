using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Bullet bulletPrefab;
    private GameObject gun;
    void Start() {
      gun = GameObject.FindWithTag("Gun");
    }

    void Update()
    {
      if (Input.GetKeyDown("space")){
            Bullet bullet = Instantiate(bulletPrefab);
            bullet.transform.parent = GameObject.Find("Interactive").transform;
            bullet.transform.localPosition = gun.transform.position;
            bullet.transform.localRotation = gun.transform.rotation;
            bullet.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
            Debug.Log(GameObject.Find("Gun").transform);
      }  
    }
}
