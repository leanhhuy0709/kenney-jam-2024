using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameManager game;
    public GameObject RoadTileCurved;
    public GameObject RoadTileStraight;
    public GameObject RoadTileFork3;
    public GameObject RoadTileOne;
    public GameObject RoadTileFork4;

    private readonly float _sizeX = 3f;
    private readonly float _sizeY = 3f;

    void Awake()
    {
        if (game == null) Debug.LogWarning("No game in MapManager");
    }

    // Start is called before the first frame update
    void Start()
    {
        InitMap();
    }

    void InitMap()
    {
        var map = new int[10, 10]
        {
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            {1, 0, 1, 0, 0, 1, 0, 1, 0, 1},
            {1, 0, 1, 0, 0, 1, 1, 1, 0, 1},
            {1, 0, 1, 0, 1, 1, 0, 1, 0, 1},
            {1, 1, 1, 1, 1, 0, 0, 1, 0, 1},
            {1, 0, 0, 0, 1, 0, 0, 0, 0, 1},
            {1, 0, 1, 1, 1, 1, 1, 1, 1, 1},
            {1, 0, 0, 0, 1, 0, 0, 0, 0, 1},
            {1, 0, 0, 0, 1, 0, 0, 0, 0, 1},
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1}
        };

        // 0 is nothing
        // 1 is curve
        // 2 is straight
        // 3 is fork 3
        // 4 is one
        // 5 is fork 4
        var mapWidth = 10;
        var mapHeight = 10;

        for (var i = 0; i < mapHeight; i++)
        {
            for (var j = 0; j < mapWidth; j++)
            {
                var isLeft = 0;
                var isRight = 0;
                var isUp = 0;
                var isDown = 0;

                var x = j;
                var y = mapHeight - 1 - i;

                if (x - 1 >= 0 && map[x - 1, y] != 0) isLeft = 1;
                if (x + 1 < mapWidth && map[x + 1, y] != 0) isRight = 1;
                if (y - 1 >= 0 && map[x, y - 1] != 0) isDown = 1;
                if (y + 1 < mapHeight && map[x, y + 1] != 0) isUp = 1;

                if (map[x, y] == 0) continue;
                var value = isDown + isRight * 2 + isUp * 4 + isLeft * 8;

                //Left Up Right Down
                GameObject tile;
                switch (value)
                {
                    case 8: // Left
                        tile = Instantiate(RoadTileOne, transform.position, Quaternion.identity);
                        tile.transform.rotation = Quaternion.Euler(0, 0, -90);
                        break;
                    case 4: // Up
                        tile = Instantiate(RoadTileOne, transform.position, Quaternion.identity);
                        tile.transform.rotation = Quaternion.Euler(0, 0, 180);
                        break;
                    case 2: // Right
                        tile = Instantiate(RoadTileOne, transform.position, Quaternion.identity);
                        tile.transform.rotation = Quaternion.Euler(0, 0, 90);
                        break;
                    case 1: // Down
                        tile = Instantiate(RoadTileOne, transform.position, Quaternion.identity);
                        tile.transform.rotation = Quaternion.Euler(0, 0, 0);
                        break;
                    case 12: // Left Up
                        tile = Instantiate(RoadTileCurved, transform.position, Quaternion.identity);
                        tile.transform.rotation = Quaternion.Euler(0, 0, 180);
                        break;
                    case 10: // Left Right
                        tile = Instantiate(RoadTileStraight, transform.position, Quaternion.identity);
                        tile.transform.rotation = Quaternion.Euler(0, 0, 90);
                        break;
                    case 9: // Left Down
                        tile = Instantiate(RoadTileCurved, transform.position, Quaternion.identity);
                        tile.transform.rotation = Quaternion.Euler(0, 0, -90);
                        break;
                    case 6: // Up Right
                        tile = Instantiate(RoadTileCurved, transform.position, Quaternion.identity);
                        tile.transform.rotation = Quaternion.Euler(0, 0, 90);
                        break;
                    case 5: // Up Down
                        tile = Instantiate(RoadTileStraight, transform.position, Quaternion.identity);
                        tile.transform.rotation = Quaternion.Euler(0, 0, 0);
                        break;
                    case 3: // Right Down
                        tile = Instantiate(RoadTileCurved, transform.position, Quaternion.identity);
                        tile.transform.rotation = Quaternion.Euler(0, 0, 0);
                        break;
                    case 14: // Left Up Right
                        tile = Instantiate(RoadTileFork3, transform.position, Quaternion.identity);
                        tile.transform.rotation = Quaternion.Euler(0, 0, 90);
                        break;
                    case 13: // Left Up Down 
                        tile = Instantiate(RoadTileFork3, transform.position, Quaternion.identity);
                        tile.transform.rotation = Quaternion.Euler(0, 0, 180);
                        break;
                    case 11: // Left Right Down 
                        tile = Instantiate(RoadTileFork3, transform.position, Quaternion.identity);
                        tile.transform.rotation = Quaternion.Euler(0, 0, -90);
                        break;
                    case 7: // Up Right Down
                        tile = Instantiate(RoadTileFork3, transform.position, Quaternion.identity);
                        tile.transform.rotation = Quaternion.Euler(0, 0, 0);
                        break;
                    case 15: // Left Up Right Down
                        tile = Instantiate(RoadTileFork4, transform.position, Quaternion.identity);
                        tile.transform.rotation = Quaternion.Euler(0, 0, 0);
                        break;
                    default:
                        tile = Instantiate(RoadTileFork4, transform.position, Quaternion.identity);
                        tile.transform.rotation = Quaternion.Euler(0, 0, 0);
                        break;
                }
                tile.transform.position = new Vector3(_sizeX * x, _sizeY * y, 0f);
                tile.transform.parent = transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

/*{
            {1, 2, 3, 2, 2, 3, 2, 3, 2, 1},
            {2, 0, 2, 0, 0, 2, 0, 2, 0, 2},
            {2, 0, 2, 0, 0, 2, 2, 3, 0, 2},
            {2, 0, 2, 0, 1, 1, 0, 2, 0, 2},
            {3, 2, 3, 2, 3, 0, 0, 2, 0, 2},
            {2, 0, 0, 0, 2, 0, 0, 0, 0, 2},
            {2, 0, 4, 2, 5, 2, 2, 2, 2, 3},
            {2, 0, 0, 0, 2, 0, 0, 0, 0, 2},
            {2, 0, 0, 0, 2, 0, 0, 0, 0, 2},
            {1, 2, 2, 2, 3, 2, 2, 2, 2, 1}
        };*/