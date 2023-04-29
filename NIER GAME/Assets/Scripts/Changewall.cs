using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changewall : MonoBehaviour
{
    GameObject Enemy;
    GameObject Boss;
    public GameObject WallPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
        Boss = GameObject.FindGameObjectWithTag("Boss");
        if (Enemy == null && Boss == null)
        {
            var wall = Instantiate(WallPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
