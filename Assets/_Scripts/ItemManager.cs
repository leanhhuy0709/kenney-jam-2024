using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameManager game;
    public Item ItemPrefab;

    public Sprite Paint;
    public Sprite Book;
    public Sprite Laptop;
    public Sprite Phone;
    public Sprite Game;
    // Start is called before the first frame update
    void Start()
    {
        InitItems();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void InitItems()
    {
        for (var i = 0; i < 15; i++)
        {
            var tile = Instantiate(ItemPrefab, transform.position, Quaternion.identity);
            tile.transform.position = game.MapManager.GetRandomValidPosition(true);
            tile.transform.parent = transform;
            tile.ItemManager = this;

            tile.transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y, -3f);

            var spriteRenderer = tile.GetComponent<SpriteRenderer>();
            var rd = Random.Range(0, 5);
            if (i < 5) rd = i;
            switch (rd)
            {
                case 0:
                    spriteRenderer.sprite = Paint;
                    tile.Type = ItemType.PAINT;
                    break;
                case 1:
                    spriteRenderer.sprite = Book;
                    tile.Type = ItemType.BOOK;
                    break;
                case 2:
                    spriteRenderer.sprite = Laptop;
                    tile.Type = ItemType.LAPTOP;
                    break;
                case 3:
                    spriteRenderer.sprite = Phone;
                    tile.Type = ItemType.PHONE;
                    break;
                case 4:
                    spriteRenderer.sprite = Game;
                    tile.Type = ItemType.GAME;
                    break;
                default:
                    spriteRenderer.sprite = Paint;
                    tile.Type = ItemType.PAINT;
                    break;
            }
        }
    }
}
