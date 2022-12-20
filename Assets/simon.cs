using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simon : MonoBehaviour
{
    // public GameObject red;
    // public GameObject green;
    // public GameObject blue;
    // public GameObject orange;

    private List<int> simon_list = new List<int>();
    private List<int> player_sequence = new List<int>();

    public List<GameObject> buttons = new List<GameObject>() ;
    public List<AudioClip> sounds = new List<AudioClip>();

    public List<Color32> highlighted_colors = new List<Color32>();

    public AudioClip lose;

    public AudioSource source;

    public GameObject startButton;

    public CanvasGroup butt;

    public void Awake(){
        highlighted_colors.Add(new Color32(255, 0, 0, 255));    //red highlight
        highlighted_colors.Add(new Color32(0, 70, 255, 255));   //blue highlight
        highlighted_colors.Add(new Color32(72, 248, 0, 255));    //green highlight
        highlighted_colors.Add(new Color32(255, 136, 0, 255));   //orange highlight
    }

    public void AddToPlayerSequenceList(int id){

        player_sequence.Add(id);
        StartCoroutine(Highlight(id));
        for(int i = 0; i < player_sequence.Count; i++){
            if(simon_list[i] == player_sequence[i]){
                continue;
            }
            else{
                return;
            }
        }
        if(simon_list.Count == player_sequence.Count){
            StartCoroutine(StartNextRound());
        }
    }

    public void StartGame(){
        StartCoroutine(StartNextRound());
        startButton.SetActive(false);
    }

    public IEnumerator StartNextRound(){
        player_sequence.Clear();
        butt.interactable = false;
        yield return new WaitForSeconds(1.0f);
        simon_list.Add(Random.Range(0, 4));

        foreach(int cur_button_id in simon_list){
            yield return StartCoroutine(Highlight(cur_button_id));
        }
        butt.interactable = true;
        yield return null;
    }

    public IEnumerator lost(){
        //AudioSource.PlayOneShot(lose);
        yield return new WaitForSeconds(2.0f);
        simon_list.Clear();
        player_sequence.Clear();
        startButton.SetActive(true);
    }

    public IEnumerator Highlight(int buttonId){
        Color32 temp_color = buttons[buttonId].GetComponent<Renderer>().material.color;
        buttons[buttonId].GetComponent<Renderer>().material.color = highlighted_colors[buttonId];
        //AudioSource.PlayOneShot(sounds[buttonId]);
        yield return new WaitForSeconds(2f);
        buttons[buttonId].GetComponent<Renderer>().material.color = temp_color;
    }

    
}
