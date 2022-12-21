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

    int curr_update;

    bool has_won;
    // Start is called before the first frame update
    void Start()
    {
        has_won = false;
        agent = GetComponent<NavMeshAgent>();
        curr_update = 0;
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
                evilNpc.SetDestination(player.position);
            }else if(dist <= 1000.0f){
                agent.speed = 7500;
                evilNpc.SetDestination(player.position);
            }else if(dist <= 2500.0f){
                agent.speed = 2500;
                evilNpc.SetDestination(player.position);
            }else{
                if(curr_update >= 10000){
                    curr_update = 0;
                    agent.speed = 1000;
                    int randX = Random.Range(1,500);
                    int randZ = Random.Range(1,500);
                    evilNpc.SetDestination(new Vector3(this.transform.position.x + randX, this.transform.position.z + randZ));
                }
                curr_update++;
            }
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
