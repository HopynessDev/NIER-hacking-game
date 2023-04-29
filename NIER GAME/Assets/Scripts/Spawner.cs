using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject a1;
    public GameObject b1;
    public GameObject c1;
    public GameObject d1;
    public Transform a2;
    public Transform b2;
    public Transform c2;
    public Transform d2;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var a = Instantiate(a1, a2.position, a2.rotation);
            var b = Instantiate(b1, b2.position, b2.rotation);
            var c = Instantiate(c1, c2.position, c2.rotation);
            var d = Instantiate(d1, d2.position, d2.rotation);
            Destroy(gameObject);
        }
        
    }
}
