using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
 
    float torque = 0.1f;
    float speed = 1.0f;
    public GameObject bullet;

    public float fireDelta = 0.5F;
    private float nextFire = 0.5F;
    private float myTime = 0.0F;
    private float fireSide;
    private bool fireRight = false;
    public new Vector3 prefabRotation;

    void FixedUpdate()
    {
 
       float v = Input.GetAxis("Vertical");
       float h = Input.GetAxis("Horizontal");
       float p = Input.GetAxis("Jump");
 
       Rigidbody rb = GetComponent<Rigidbody>();
 
       rb.AddForce(transform.forward * speed * p);
       rb.AddTorque(transform.up * torque * h);
       rb.AddTorque(transform.right * torque * v);
    }
    
 
    void Update()
    {
       myTime = myTime + Time.deltaTime;
 
       if (Input.GetButton("Fire2") && myTime > nextFire)
       {
           nextFire = myTime + fireDelta;
           if(fireRight){
            fireSide = transform.position.x +5;
            fireRight = false;
            }
           else{
            fireSide = transform.position.x -5;
            fireRight = true;
           }
 
           Vector3 source = new Vector3(fireSide,transform.position.y-2,transform.position.z);
           GameObject instancia = Instantiate(bullet,source + (transform.forward*2), transform.rotation) as GameObject;
           instancia.transform.Rotate (prefabRotation);
           instancia.GetComponent<Rigidbody>().velocity = 100.0f * transform.forward;
           Destroy(instancia, 5.0f); // Destroi o tiro depois de 5 segundos
           nextFire = nextFire - myTime;
           myTime = 0.0F;
       }
    }

}
