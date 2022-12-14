using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruit1GamePlate3 : MonoBehaviour
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
            if( gm.fruit1Game == 2){
                gm.fruit1Game = 3;
                gm.PlayPlatformFoundSound();
                this.GetComponent<Renderer>().material.color = new Color(0f, 1f, 0f);
                isPressed = true;
            }else{
                if(!isPressed){
                    gm.PlayWrongAnswerSound();
                    gm.fruit1Game = -1;
                }
            }
        }
    }
}
