using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EvilNpc : MonoBehaviour
{   
    public NavMeshAgent evilNpc;

    public Transform player;

    private NavMeshAgent agent;

    bool has_won;
    // Start is called before the first frame update
    void Start()
    {
        has_won = false;
        agent = GetComponent<NavMeshAgent>();
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
            float dist = Vector3.Distance(this.transform.position, player.transform.position);

            if(dist <= 100.0f){
                agent.speed = 9000;
            }else if(dist <= 1000.0f){
                agent.speed = 7500;
            }else if(dist <= 2500.0f){
                agent.speed = 2500;
            }else{
                agent.speed = 0;
            }
            evilNpc.SetDestination(player.position); 
        }else{
            evilNpc.SetDestination(this.transform.position);
        }
        
           
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Mungo" && !has_won){
            SceneManager.LoadScene("LostScene");
        }
    }
}
