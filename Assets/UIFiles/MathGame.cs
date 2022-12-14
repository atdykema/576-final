using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MathGame : MonoBehaviour
{
    
    public Text value_txt;    // display new item value
    public Text net_val_txt;  // display mungo's net value
    public InputField answer_field; // user types math answer
    public Mungo mungo;             // provide mungo for game variables
    public Item currentItem;        // the new item picked up
    public Image food_img_1;
    public Image food_img_2;

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
        
        try {
            int.Parse(answer);
            if (int.Parse(answer) != correct) {
                Debug.Log("the math is wrong");
                mungo.EndMathGame();
            } else {
                mungo.AddItemToInventory(new Item { itemType = Item.ItemType.Eggs, amount = 1, level=mungo.level });
                mungo.EndMathGame();
            }
        } catch(Exception e) {
            // the user did not enter a number
            Debug.Log("enter a valid number");
        }
    }

}
