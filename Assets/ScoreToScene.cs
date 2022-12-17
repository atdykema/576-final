using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreToScene : MonoBehaviour
{
    Text score;
    public Text textBox;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        score = GameObject.Find("Mungo").GetComponent<Mungo>().mathGame.net_val_txt;
        textBox.text = score.ToString();
    }
}
