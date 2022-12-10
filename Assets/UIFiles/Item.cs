using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    public ItemType itemType;
    public int amount;
    public int level;
    
    private List<int>[,,] foodValue;

    public enum ItemType
    {
        PurpleFood,
        Cake,
        Avacado,
        Strawberry,
        Eggs,
        Apple
    }

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Apple:         return ItemAssets.Instance.appleSprite;
            case ItemType.PurpleFood:    return ItemAssets.Instance.purpleFoodSprite;
            case ItemType.Eggs:          return ItemAssets.Instance.eggsSprite;
            case ItemType.Cake:          return ItemAssets.Instance.cakeSprite;
            case ItemType.Avacado:       return ItemAssets.Instance.avacadoSprite;
            case ItemType.Strawberry:       return ItemAssets.Instance.strawberrySprite;
        }
    }

    public int GetValue()
    {
        Debug.Log($"Level:{level}");
        if (level == 1)
        {
            switch (itemType)
            {
                default:
                case ItemType.PurpleFood:       return 5000;
                case ItemType.Cake:             return 300;
                case ItemType.Avacado:          return 100;
                case ItemType.Strawberry:       return 100;
                case ItemType.Eggs:             return 50;
                case ItemType.Apple:            return 10;
            }
        }
        else if (level == 2)
        {
            switch (itemType)
            {
                default:
                case ItemType.PurpleFood:       return 5020;
                case ItemType.Cake:             return 350;
                case ItemType.Avacado:          return 150;
                case ItemType.Strawberry:       return 150;
                case ItemType.Eggs:             return 50;
                case ItemType.Apple:            return 15;
            }
        }
        else
        {
            switch (itemType)
            {
                default:
                case ItemType.PurpleFood:       return 5165;
                case ItemType.Cake:             return 312;
                case ItemType.Avacado:          return 123;
                case ItemType.Strawberry:       return 132;
                case ItemType.Eggs:             return 51;
                case ItemType.Apple:            return 12;
            }
        }
    }

    public bool IsStackable() 
    {
        return true;

        // if we wanted some not to have more than
        // one item listed clumped together (like health or something)
        /*
        switch (itemType)
        {
            default:
            case ItemType.Apple:
            case ItemType.Eggs:
                return true;
            case ItemType.PurpleFood:    
                return false;
        }
        */
        
    }
}
