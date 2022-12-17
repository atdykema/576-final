using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EvilNpc : MonoBehaviour
{   
    public NavMeshAgent evilNpc;

    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        evilNpc.SetDestination(player.position);    
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Mungo"){
            SceneManager.LoadScene("StartScene");
        }
    }
}
