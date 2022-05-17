using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGun : MonoBehaviour
{
    public Transform Spawnpoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        //Spawnpoint = this.SearchForChild("Spawnpoint");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        Debug.Log("Shoot");
        GameObject bullet = Instantiate(bulletPrefab, Spawnpoint.position, Spawnpoint.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(Spawnpoint.forward * bulletSpeed);
    }
}
