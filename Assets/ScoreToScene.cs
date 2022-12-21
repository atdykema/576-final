using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreToScene : MonoBehaviour
{
    int score;
    public Text textBox;

    public AudioClip wonSound;
    private AudioSource source; 

    void Start() {
        source = gameObject.AddComponent<AudioSource>();
        source.PlayOneShot(wonSound,1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        score = GameObject.Find("Mungo").GetComponent<Mungo>().uiInventory.total;
        textBox.text = score.ToString();
    }
}
