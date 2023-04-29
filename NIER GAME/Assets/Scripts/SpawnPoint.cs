using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Spawn");
        if (gameObject == Target)
        {
            Target = GameObject.FindGameObjectWithTag("Spawn");
        }
        Destroy (Target);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
