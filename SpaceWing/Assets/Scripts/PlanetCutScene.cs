using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetCutScene : MonoBehaviour
{
    public GameObject Cam1;
    // public GameObject Cam2;
    public GameObject Player;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Sequence());

    }

    IEnumerator Sequence(){
        yield return new WaitForSeconds(7.183f);
        Cam1.SetActive(false);
        Player.SetActive(true);

    }
}
