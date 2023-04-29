using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public Transform particleSpawnPoint;
    public GameObject ParticlePrefab;
    public int life = 1;
    public bool boss;
    bool shield = false;
    GameObject Enemy;
    public Material Material1;
    // Start is called before the first frame update
    void Start()
    {
        if (boss)
        {   
            shield = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
        if (Enemy == null  && boss)
        {
            shield = false;
            gameObject.GetComponent<MeshRenderer> ().material = Material1;
        }
    }


    void OnCollisionEnter(Collision other) 
    {
        if (shield == false)
        {
            
            if (other.gameObject.CompareTag("Bullet"))
            {
                life -= 1;  
                StartCoroutine("TakeDamage");
                if (life <= 0)
                {
                    Destroy(gameObject);
                }    
            }
        
        }
    }

    IEnumerator TakeDamage() 
    {
        var particles = Instantiate(ParticlePrefab,particleSpawnPoint.position, Quaternion.Euler(-90,0,0));
        yield return new WaitForSeconds(0.3f);
        Destroy(particles);
    }   
}