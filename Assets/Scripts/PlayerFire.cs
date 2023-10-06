using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public Transform spawnBulletHere;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public float fireRate = 10;
    private float BaseFireRate; 


    // Start is called before the first frame update
    void Start()
    {
        BaseFireRate = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        fireRate -= Time.deltaTime;
        if (fireRate <= 0)
        {
            Shoot();
        }

       /* if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            em.isCOnnected = false;
        }*/
        
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, spawnBulletHere.position, spawnBulletHere.rotation);
        Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();

        bulletRB.AddForce(spawnBulletHere.forward * bulletSpeed, ForceMode.Impulse);
        fireRate = BaseFireRate; 
    }
}
