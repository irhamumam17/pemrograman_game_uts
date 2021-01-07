using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool btn1;
    public bool btn2;
    public Button btnPlay;
    public GameObject exitConfirmation;
    public GameObject infoPanel;
    void Start()
    {
        btn1 = false;
        btn2 = false;
        btnPlay.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void select1(){
        btn1 = true;
        btnPlay.interactable = true;
    }
    public void select2(){
        btn2 = true;
        btnPlay.interactable = true;
    }
    public void play(){
        if(btn1==true){
            PlayerPrefs.SetInt("multiplayer",0);
        }else if(btn2==true){
            PlayerPrefs.SetInt("multiplayer",1);
        }
        SceneManager.LoadScene("SceneMain");
    }
    public void exit(){
        exitConfirmation.SetActive(true);
    }
    public void onExitSelected(){
        Application.Quit();
    }
    public void onNoExitSelected(){
        exitConfirmation.SetActive(false);
    }
    public void displayInfo(){
        infoPanel.SetActive(true);
    }
    public void infoExit(){
        infoPanel.SetActive(false);
    }
}
