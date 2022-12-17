using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EvilNpc : MonoBehaviour
{   
    public NavMeshAgent evilNpc;

    public Transform player;

    bool has_won;
    // Start is called before the first frame update
    void Start()
    {
        has_won = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("tab")) {
            if(has_won == false){
                has_won = true;
            }else{
                has_won = false;
            }
        }

        if(!has_won){
            evilNpc.SetDestination(player.position); 
        }else{
            evilNpc.SetDestination(this.transform.position);
        }
        
           
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Mungo" && !has_won){
            SceneManager.LoadScene("StartScene");
        }
    }
}
