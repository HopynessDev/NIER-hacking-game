using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{

    [SerializeField] int life = 3;
    public Transform lifeLeftSpawnPoint;
    public Transform lifeRightSpawnPoint;
    public GameObject LifePrefab;
    GameObject SpawnPoint;
    int Change = 0;
    GameObject RightLife;
    GameObject LeftLife;

    // Start is called before the first frame update
    void Start()
    {
        LeftLife = Instantiate(LifePrefab, lifeLeftSpawnPoint.position, lifeLeftSpawnPoint.rotation, lifeLeftSpawnPoint);
        RightLife = Instantiate(LifePrefab, lifeRightSpawnPoint.position, lifeRightSpawnPoint.rotation, lifeRightSpawnPoint);
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 2 && Change == 0)
        {
            Destroy(LeftLife);
            Change += 1;
        }
        else if (life <= 1 && Change == 1)
        {
            Destroy(RightLife);
            Change += 1;
        }
        else if (life <= 0 && Change == 2)
        {
            Respawn();
            Change = 0;
            
        }
    }

    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            life -= 1;       
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("EtherealBullet"))
        {
            life -= 1;       
        }
    }

    void Respawn()
    {
        SpawnPoint = GameObject.FindGameObjectWithTag("Spawn");
        transform.position = SpawnPoint.transform.position;
        life = 3;
        LeftLife = Instantiate(LifePrefab, lifeLeftSpawnPoint.position, lifeLeftSpawnPoint.rotation, lifeLeftSpawnPoint);
        RightLife = Instantiate(LifePrefab, lifeRightSpawnPoint.position, lifeRightSpawnPoint.rotation, lifeRightSpawnPoint);


    }
}
