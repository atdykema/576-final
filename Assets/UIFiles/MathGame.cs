using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MathGame : MonoBehaviour
{
    
    public GameManager gm;
    public Text value_txt;    // display new item value
    public Text net_val_txt;  // display mungo's net value
    public InputField answer_field; // user types math answer
    public Mungo mungo;             // provide mungo for game variables
    public Item currentItem;        // the new item picked up
    public Image food_img_1;
    public Image food_img_2;
    public Text wrong_ansr_txt;
    public GameObject wrong_ansr_bg;
    private bool toggledAlready = false;

    

    internal float timestamp_wrong_answer = float.MaxValue;

    public void ResetGame() {
        value_txt.text = currentItem.GetValue().ToString();
        net_val_txt.text = mungo.uiInventory.total.ToString();
        answer_field.text = "";
        food_img_1.sprite = currentItem.GetSprite();
        food_img_2.sprite = currentItem.GetSprite();
    }

    // call when user presses 'return' or 
    // the enter button on the screen
    // checks if math is correct
    public void enterMathVal() {
        string answer = answer_field.text;
        int correct = mungo.uiInventory.total + currentItem.GetValue();
        toggledAlready = false;
        try {
            int.Parse(answer);
            if (int.Parse(answer) != correct) {
                timestamp_wrong_answer = Time.unscaledTime;
                gm.PlayWrongAnswerSound();
                wrong_ansr_txt.text = "Wrong Answer!\nFood Abandoned";
                mungo.EndMathGame();
            } else {
                timestamp_wrong_answer = Time.unscaledTime;
                wrong_ansr_txt.text = "Correct!\nAdded to Inventory";
                mungo.AddItemToInventory(mungo.collidedItem);
                mungo.EndMathGame();
            }
        } catch(Exception e) {
            // the user did not enter a number
            Debug.Log("enter a valid number");
        }
    }

    // Update is called once per frame
    void Update() {
        float time_since_wrong_answer = Time.unscaledTime - timestamp_wrong_answer;
        if (time_since_wrong_answer > 4.0f) {
            wrong_ansr_bg.SetActive(false);
            if (!toggledAlready) {
                mungo.ShowMungoInventory();
                mungo.mathGameOpen = false;
                mungo.isPaused = false;
                toggledAlready = true;
            }
        } else if (time_since_wrong_answer > 0.75f) {
            wrong_ansr_bg.SetActive(true);
        }
    }
}
