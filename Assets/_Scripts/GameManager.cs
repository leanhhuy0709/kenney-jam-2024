using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public MapManager MapManager;
    public ItemManager ItemManager;


    public List<Image> Image;
    public int CountComplete;
    private bool[] visited = { false, false, false, false, false };
    // Start is called before the first frame update
    void Start()
    {
        // foreach (var image in Image)
        // {
        // Image[0];
        if (ItemManager)
        {
            Image[0].sprite = ItemManager.Book;
            Image[1].sprite = ItemManager.Game;
            Image[2].sprite = ItemManager.Paint;
            Image[3].sprite = ItemManager.Phone;
            Image[4].sprite = ItemManager.Laptop;
        }
        // }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetItem(ItemType type)
    {
        switch (type)
        {
            case ItemType.BOOK:
                if (Image[0].color == Color.black && !visited[0])
                {
                    visited[0] = true;
                    CountComplete++;
                }
                Image[0].color = Color.white;
                break;
            case ItemType.GAME:
                if (Image[1].color == Color.black && !visited[1])
                {
                    visited[1] = true;
                    CountComplete++;
                }
                Image[1].color = Color.white;
                break;
            case ItemType.PAINT:
                if (Image[2].color == Color.black && !visited[2])
                {
                    visited[2] = true;
                    CountComplete++;
                }
                Image[2].color = Color.white;
                break;
            case ItemType.PHONE:
                if (Image[3].color == Color.black && !visited[3])
                {
                    visited[3] = true;
                    CountComplete++;
                }
                Image[3].color = Color.white;
                break;
            default:
                if (Image[4].color == Color.black && !visited[4])
                {
                    visited[4] = true;
                    CountComplete++;
                }
                Image[4].color = Color.white;
                break;
        }
        if (CountComplete == 5)
        {
            Debug.Log("Win");
            SceneManager.LoadScene("WinScene");
        }
    }

    public void MoveToGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
