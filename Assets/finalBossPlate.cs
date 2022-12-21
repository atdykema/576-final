using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalBossPlate : MonoBehaviour
{
    public GameManager gm;
    private bool isPressed;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        isPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Mungo"){
            if(!isPressed){
                gm.PlayPlatformFoundSound();
                gameObject.GetComponent<Renderer>().material.color = new Color(0f, 1f, 0f);
                gm.finalBossGame++;
                isPressed = true;
            }
        }
    }
}
