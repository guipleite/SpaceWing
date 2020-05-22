using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ship : MonoBehaviour
{
 
    float torque = 0.2f;
    float speed = 1.0f;
    public GameObject bullet;

    public float fireDelta = 0.5F;
    private float nextFire = 0.5F;
    private float myTime = 0.0F;
    private float fireSide;
    private bool fireRight = false;
    public new Vector3 prefabRotation;
    public CameraShake cameraShake;
    public AudioSource audioSource;
    public AudioClip sound;
    public AudioClip sound2;
    public GameObject ShieldBar;
    public int HP = 3;


    void OnCollisionEnter(Collision collision) {
       if (collision.gameObject.tag == "Asteroid") {        
            Debug.Log("Ouch")  ;  
            HP-=1;   
            StartCoroutine(cameraShake.Shake(0.3f, 0.6f));

            if(HP == 2 ){ShieldBar.GetComponent<Text>().text = ("I I");}
            if(HP == 1 ){ShieldBar.GetComponent<Text>().text = ("I");}
            if(HP<=0){
                audioSource.PlayOneShot(sound2);

                ShieldBar.GetComponent<Text>().text = ("");
                Destroy(gameObject, 4.0f);
                SceneManager.LoadScene("MainMenu") ; 
    
            }
        }
    }
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
 
       if (Input.GetButton("Fire1") && myTime > nextFire)
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
           audioSource.PlayOneShot(sound);

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
