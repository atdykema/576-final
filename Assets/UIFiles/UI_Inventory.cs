using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour {
    
    public GameObject strawberry_obj;
    public GameObject avacado_obj;
    public GameObject cake_obj;
    public GameObject eggs_obj;
    public GameObject purplefood_obj;
    public GameObject apple_obj;
    List<GameObject> food_obj_list = new List<GameObject>();

    private Inventory inventory;
    public Text totalNetValTxt;

    public GameObject itemSlotContainer;
    public GameObject itemSlotTemplate;

    public int total = 0;   // keep track of mungos net value

    private int nextItemToDrop = 0;
    public Mungo mungo;
    
    public void SetInventory(Inventory inventory) {
        this.inventory = inventory;
        food_obj_list.Add(strawberry_obj);
        food_obj_list.Add(avacado_obj);
        food_obj_list.Add(cake_obj);
        food_obj_list.Add(eggs_obj);
        food_obj_list.Add(apple_obj);
        food_obj_list.Add(purplefood_obj);

        RefreshInventoryItems();
    }

    public void RefreshInventoryItems() {
        // remove existing transforms in the container
        DestroyExistingInventory();

        int x = 0;
        int y = 0;
        int intemSlotCellSize = 85;
        foreach(Item item in inventory.GetItemList())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate.transform, itemSlotContainer.transform).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            Button itemBtn = itemSlotRectTransform.GetComponent<Button>();
            
            itemBtn.onClick.AddListener(delegate {RemoveInventoryItem(item); });
            itemSlotRectTransform.anchoredPosition = new Vector2(x * intemSlotCellSize, y * intemSlotCellSize);
            Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();
            image.sprite = item.GetSprite();
            Text value_txt = itemSlotRectTransform.Find("itemLabel").GetComponent<Text>();
            value_txt.text = "$" + item.GetValue().ToString();
            Text count_txt = itemSlotRectTransform.Find("itemCount").GetComponent<Text>();
            if (item.amount > 1) {
                count_txt.text = item.amount.ToString();
                total = total + (item.GetValue() * item.amount);
            } else {
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

    private void DestroyExistingInventory() {
        foreach (GameObject go in UnityEngine.Object.FindObjectsOfType(typeof(GameObject))) {
            if(go.name == "itemSlotTemplate(Clone)" ) {
                Destroy(go);
            }
        }
    }

    public void RemoveInventoryItem(Item item) {
        inventory.RemoveItem(item);
        RefreshInventoryItems();
    }

    public void DropInventoryItem() {
        Debug.Log("Dropping an inventory Item");
        Vector3 player_pos = mungo.transform.position;
        if (nextItemToDrop < 6) {
            GameObject drop_item = food_obj_list[nextItemToDrop];
            nextItemToDrop = nextItemToDrop + 1;
            Vector3 drop_pos = new Vector3(player_pos.x+150, player_pos.y, player_pos.z+150);
            drop_item.transform.position = drop_pos;
        } else {
            Debug.Log("All Items have been dropped");
        }
    }
}
