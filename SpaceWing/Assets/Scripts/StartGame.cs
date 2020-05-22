using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private AssetBundle myLoadedAssetBundle;
    private bool GameStart = false;
    public GameObject button;

    void Start()
    {
        GameStart = false;
    }

    public void OnButtonClick(){

        var go = EventSystem.current.currentSelectedGameObject;
        // if (EventSystem.current.IsPointerOverGameObject () && EventSystem.current.currentSelectedGameObject != null){
        if (go ==button){
            GameStart = true;
            SceneManager.LoadScene("Space") ; 
        }
    }

    void Update()
    {
        if(!GameStart){

            OnButtonClick();
        }
    }
}
