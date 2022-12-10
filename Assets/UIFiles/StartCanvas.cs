using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartCanvas : MonoBehaviour
{
    public GameObject mungoTitleTxt;
    public GameObject instructionTxt;
    public GameObject startBtn;
    public GameObject startCanvas;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("In Start Method");
        ShowStartMenu();
    }

    // Called when user presses: 
    // Start Helping Mungo
    public void StartPressed()
    {
        // Maybe a load scene here?
        Debug.Log("starting to play Mungo");
        // HideStartMenu();
        SceneManager.LoadScene("MainScene");
    }

    public void HideStartMenu()
    {
        startCanvas.SetActive(false);
        //mungoTitleTxt.SetActive(false);
        //instructionTxt.SetActive(false);
        //startBtn.SetActive(false);
    }

    public void ShowStartMenu()
    {
        startCanvas.SetActive(true);
        //mungoTitleTxt.SetActive(true);
        //instructionTxt.SetActive(true);
        //startBtn.SetActive(true);
    }
}
