using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<Item> itemList;
    public int level = 1;

    public Inventory() 
    {
        itemList = new List<Item>();
        //AddItem(new Item { itemType = Item.ItemType.PurpleFood, amount = 1, level=level });
        //AddItem(new Item { itemType = Item.ItemType.Cake, amount = 1, level=level});
        //AddItem(new Item { itemType = Item.ItemType.Avacado, amount = 1, level=level });
        //AddItem(new Item { itemType = Item.ItemType.Strawberry, amount = 1, level=level });
        //AddItem(new Item { itemType = Item.ItemType.Eggs, amount = 1, level=level });
        //AddItem(new Item { itemType = Item.ItemType.Apple, amount = 1, level=level });
    }

    public void RemoveItem(Item item)
    {
        if (item.IsStackable())
        {
            Item itemInInventory = null;
            foreach(Item inventoryItem in itemList)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.amount = inventoryItem.amount - 1;
                    itemInInventory = inventoryItem;
                }
            }
            if (itemInInventory != null && itemInInventory.amount <= 0)
            {
                itemList.Remove(item);
            }
        }
        else
        {
            itemList.Remove(item);
        }
    }

    public void AddItem(Item item)
    {
        if (item.IsStackable())
        {
            bool alreadyInInventory = false;
            foreach(Item inventoryItem in itemList)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.amount += item.amount;
                    alreadyInInventory = true;
                }
            }
            if (!alreadyInInventory)
            {
                itemList.Add(item);
            }
        }
        else
        {
            itemList.Add(item);
        }
    }
    
    public List<Item> GetItemList() 
    {
        return itemList;
    }

}
