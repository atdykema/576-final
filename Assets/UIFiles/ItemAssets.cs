using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }

    public Sprite purpleFoodSprite;
    public Sprite appleSprite;
    public Sprite eggsSprite;
    public Sprite cakeSprite;
    public Sprite avacadoSprite;
    public Sprite strawberrySprite;

    private void Awake()
    {
        Instance = this;
    }
}
