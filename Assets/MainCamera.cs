using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public GameObject mungo;
    // Start is called before the first frame update
    void Start()
    {
        mungo = GameObject.Find("Mungo");
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = mungo.transform.position + new Vector3(0, 200, -300);
        transform.rotation = mungo.transform.rotation;
    }
}
