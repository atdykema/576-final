using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        Debug.Log("coming from fruit script");
        if(other.name == "Mungo"){
            GameObject.Find("Mungo").GetComponent<Mungo>().fruitList[fruitNumber] = 1;
            this.gameObject.SetActive(false);
            if(fruitNumber == 5){
                SceneManager.LoadScene("ScoreScreen");
            }
        }

        
    }

}

