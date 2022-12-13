using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitScript : MonoBehaviour
{

    public int fruitNumber;
    // Start is called before the first frame update
    void Start()
    {
    
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.name == "Mungo"){
            GameObject.Find("Mungo").GetComponent<Mungo>().fruitList[fruitNumber] = 1;
            this.gameObject.SetActive(false);
        }
        
    }

}

