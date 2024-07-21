using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    PAINT,
    BOOK,
    LAPTOP,
    PHONE,
    GAME
}

public class Item : MonoBehaviour
{
    public ItemManager ItemManager;
    public ItemType Type;
    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerEnter2D()
    {
        if (ItemManager)
        {
            ItemManager.game.GetItem(Type);
        }
        Destroy(gameObject);
    }
}
