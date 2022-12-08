using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruit1GamePlate1 : MonoBehaviour
{   
    public GameManager gm;
    public bool isPressed;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        this.GetComponent<Renderer>().material.color = new Color(0f, 0f, 0f);
        isPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.name == "Mungo"){
            if( gm.fruit1Game == 0){
                gm.fruit1Game = 1;
                this.GetComponent<Renderer>().material.color = new Color(0f, 1f, 0f);
                isPressed = true;
            }else{
                if(!isPressed){
                    gm.fruit1Game = -1;
                }
            }
        }
    }
}
