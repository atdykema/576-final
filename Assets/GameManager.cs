using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public int fruit1Game;
    public GameObject fruit1;
    public GameObject fruit1GamePlate1;
    public GameObject fruit1GamePlate2;
    public GameObject fruit1GamePlate3;
    public GameObject fruit1GamePlate4;


    void Awake(){
        gameManager = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        fruit1Game = 0;
        fruit1 = GameObject.Find("Fruit1");
        fruit1GamePlate1 = GameObject.Find("fruit1GamePlate1");
        fruit1GamePlate2 = GameObject.Find("fruit1GamePlate2");
        fruit1GamePlate3 = GameObject.Find("fruit1GamePlate3");
        fruit1GamePlate4 = GameObject.Find("fruit1GamePlate4");
        
        fruit1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(fruit1Game == -1){
            fruit1GamePlate1.GetComponent<Renderer>().material.color = new Color(0f, 0f, 0f);
            fruit1GamePlate2.GetComponent<Renderer>().material.color = new Color(0f, 0f, 0f);
            fruit1GamePlate3.GetComponent<Renderer>().material.color = new Color(0f, 0f, 0f);
            fruit1GamePlate4.GetComponent<Renderer>().material.color = new Color(0f, 0f, 0f);
            fruit1Game = 0;
        }
    }
}
