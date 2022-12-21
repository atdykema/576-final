using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    public int fruit1Game;
    public GameObject fruit1;
    public GameObject fruit1GamePlate1;
    public GameObject fruit1GamePlate2;
    public GameObject fruit1GamePlate3;
    public GameObject fruit1GamePlate4;

    public int finalBossGame;
    public GameObject fruit5;
    public GameObject finalBossPlate1;
    public GameObject finalBossPlate2;
    public GameObject finalBossPlate3;
    public GameObject finalBossPlate4;

    public AudioClip fruitAppears;
    public AudioClip collectedFruit;
    public AudioClip countMoney;
    public AudioClip wrongAnswer;

    private AudioSource source;

    void Awake(){
        gameManager = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        source = gameObject.AddComponent<AudioSource>();

        fruit1Game = 0;
        fruit1 = GameObject.Find("fruit1");
        fruit1GamePlate1 = GameObject.Find("fruit1GamePlate1");
        fruit1GamePlate2 = GameObject.Find("fruit1GamePlate2");
        fruit1GamePlate3 = GameObject.Find("fruit1GamePlate3");
        fruit1GamePlate4 = GameObject.Find("fruit1GamePlate4");
        
        fruit1.SetActive(false);

        finalBossGame = 0;
        fruit5 = GameObject.Find("fruit5");
        finalBossPlate1 = GameObject.Find("finalBossPlate1");
        finalBossPlate2 = GameObject.Find("finalBossPlate2");
        finalBossPlate3 = GameObject.Find("finalBossPlate3");
        finalBossPlate4 = GameObject.Find("finalBossPlate4");

        fruit5.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(fruit1Game == -1){
            fruit1GamePlate1.GetComponent<Renderer>().material.color = new Color(0f, 0f, 0f);
            fruit1GamePlate2.GetComponent<Renderer>().material.color = new Color(0f, 0f, 0f);
            fruit1GamePlate3.GetComponent<Renderer>().material.color = new Color(0f, 0f, 0f);
            fruit1GamePlate4.GetComponent<Renderer>().material.color = new Color(0f, 0f, 0f);
            fruit1Game = 0;
        }

        Debug.Log($"finalBossGame{finalBossGame}");
        if(finalBossGame == 4){
            PlayFruitAppearsSound();
            fruit5.SetActive(true);
        }
    }

    public void PlayFruitAppearsSound() {
        source.PlayOneShot(fruitAppears,1.0f);
    }

    public void PlayCollectedFruitSound() {
        source.PlayOneShot(collectedFruit,1.0f);
    }

    public void PlayMoneySound() {
        source.PlayOneShot(countMoney,1.0f);
    }

    public void PlayWrongAnswerSound() {
        source.PlayOneShot(wrongAnswer,1.0f);
    }
}
