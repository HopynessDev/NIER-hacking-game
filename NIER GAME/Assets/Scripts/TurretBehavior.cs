using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehavior : MonoBehaviour
{
    GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Target.transform.position);
        transform.rotation = Quaternion.Euler(0,transform.localEulerAngles.y,0);
    }


}
