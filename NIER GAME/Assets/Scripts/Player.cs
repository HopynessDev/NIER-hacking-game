using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    float speed;
    float movX;
    float movZ;
    Vector3 direction;
    Rigidbody rb;
    bool dashCD = true;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        movX = 0;
        movZ = 0;
        Inputs();
        Movement();
    }

        

    void Inputs()
    {

        if (Input.GetKey(KeyCode.W))
        {
            movZ = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movZ = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movX = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movX = -1;
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            Dash();
        }
    }

    void Movement()
    {
        speed = moveSpeed * Time.deltaTime;
        direction = Vector3.right * movX + Vector3.forward * movZ; //new Vector3(movX,0,movZ);
        rb.AddForce(direction.normalized * speed * 10f, ForceMode.Force);
    }

    void Dash()
    {
        if (dashCD)
        {
            rb.AddForce(direction.normalized * speed * 2000f, ForceMode.Force);
            StartCoroutine("DashCoolDown");
        }
        
    }

    IEnumerator DashCoolDown()
    {
        dashCD = false;
        yield return new WaitForSeconds(1f);
        dashCD = true;
    }


}
