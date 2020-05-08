using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Planet : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
       if (other.CompareTag("Player")) {        
           SceneManager.LoadScene("Planet");
       }
   }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
