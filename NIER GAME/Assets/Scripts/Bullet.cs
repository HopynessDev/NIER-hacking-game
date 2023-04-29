using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3f;
    public bool ethereal = false;

    void Awake() 
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter(Collision other) 
    {
        if (ethereal)
        {
            if (other.gameObject.CompareTag("Bullet") == false)
            {
                Destroy(gameObject);
            }
        }

        else
        {
            if (other.gameObject.CompareTag("EtherealBullet") == false)
            {
                Destroy(gameObject);
            }
        }
        
    }
    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("Destructible"))
            {
                Destroy(gameObject);
            }
    }
}

//    if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Destructible") )
//        {
//            Life otherLife = other.gameObject.GetComponent<Life>();
//            otherLife.life -= 1;  
//            Destroy(gameObject);          
//        }
        