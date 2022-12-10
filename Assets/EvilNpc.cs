using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
}
