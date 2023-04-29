using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject BulletPrefab;
    public GameObject BulletPrefab2;
    private float bulletSpeed = 10f;
    private float time = 0.0f;
    public float interpolationPeriod = 0.1f;
    public float interpolationPeriodStart = 0.1f;
    public float interpolationPeriodStart2 = 0.1f;
    public bool bullet2 = true;
    private bool start = true;
    private bool start2 = true;


    void Start()
    { 
        StartCoroutine("BulletSpawn");

        if (bullet2)
        {
            StartCoroutine("BulletSpawn2");
        }
    }

    IEnumerator BulletSpawn() 
    {
        for(;;) 
        {
            if (start)
            {
                start = false;
                yield return new WaitForSeconds(0.5f);
                yield return new WaitForSeconds(interpolationPeriodStart);
            }
            
            yield return new WaitForSeconds(interpolationPeriod);
            var bullet = Instantiate(BulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
            



        }
    }

    IEnumerator BulletSpawn2() 
    {
        for(;;) 
        {
            if (start2)
            {
                start2 = false;
                yield return new WaitForSeconds(0.5f);
                yield return new WaitForSeconds(interpolationPeriodStart2);
            }
            
            yield return new WaitForSeconds(interpolationPeriod);
            var bullet2 = Instantiate(BulletPrefab2, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet2.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
            



        }
    }
}
