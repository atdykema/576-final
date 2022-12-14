using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    
    private Inventory inventory;
    //private Transform itemSlotContainer;
    //private Transform itemSlotTemplate;
    public Text totalNetValTxt;

    public GameObject itemSlotContainer;
    public GameObject itemSlotTemplate;
    public int total = 0;   // keep track of mungos net value

    private Item removingItem;
    //itemToRemoveList = new List<Item>();

    public void SetInventory(Inventory inventory) 
    {
        this.inventory = inventory;
        RefreshInventoryItems();
    }

    public void RefreshInventoryItems()
    {
        // remove existing transforms in the container
        DestroyExistingInventory();
        total = 0;
        int x = 0;
        int y = 0;
        int intemSlotCellSize = 85;
        foreach(Item item in inventory.GetItemList())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate.transform, itemSlotContainer.transform).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            Button itemBtn = itemSlotRectTransform.GetComponent<Button>();
            
            // add item value to total
            

            itemBtn.onClick.AddListener(delegate {RemoveInventoryItem(item); });
            //itemBtn.onClick.AddListener(() => {LogName(itemBtn); });
            //itemBtn.onClick.AddListener(TaskOnClick);
            itemSlotRectTransform.anchoredPosition = new Vector2(x * intemSlotCellSize, y * intemSlotCellSize);
            Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();
            image.sprite = item.GetSprite();
            Text value_txt = itemSlotRectTransform.Find("itemLabel").GetComponent<Text>();
            value_txt.text = "$" + item.GetValue().ToString();
            Text count_txt = itemSlotRectTransform.Find("itemCount").GetComponent<Text>();
            if (item.amount > 1)
            {
                count_txt.text = item.amount.ToString();
                total = total + (item.GetValue() * item.amount);
            }
            else 
            {
                count_txt.text = "";
                total = total + item.GetValue();
            }
            x++;
            if (x > 1)
            {
                x = 0;
                y--;
            }
        }
        totalNetValTxt.text = "$" + total.ToString();
    }

    private void DestroyExistingInventory()
    {
        foreach (GameObject go in UnityEngine.Object.FindObjectsOfType(typeof(GameObject)))
        {
            if(go.name == "itemSlotTemplate(Clone)" )
            {
                Destroy(go);
            }
        }
    }

    public void RemoveInventoryItem(Item item)
    {
        inventory.RemoveItem(item);
        RefreshInventoryItems();
    }
}
