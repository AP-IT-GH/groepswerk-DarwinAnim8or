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
      if (Input.GetButton("Fire1")){
        Shoot();
      }  
    }

    public void Shoot(){
            Bullet bullet = Instantiate(bulletPrefab);
            bullet.transform.parent = GameObject.Find("BULLETOBJECT").transform;
            bullet.transform.position = gun.transform.position;
            bullet.transform.rotation = gun.transform.rotation;
            bullet.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
    }
}
