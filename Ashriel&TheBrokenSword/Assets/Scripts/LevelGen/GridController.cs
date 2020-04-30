using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public Room room;
    [System.Serializable]

    public struct Grid
    {
        public int columns, rows;
        public float verticalOffSet, horizontalOffset;

    }

    public Grid grid;

    public GameObject gridTile;
    public List<Vector2> avaliablePoints = new List<Vector2>();

    private void Awake()
    {
        room = GetComponentInParent<Room>();
        grid.columns = room.width - 2;
        grid.rows = room.height - 1;
        GenerateGrid();
    }

    public void GenerateGrid()
    {
        grid.verticalOffSet += room.transform.localPosition.y;
        grid.horizontalOffset += room.transform.localPosition.x;

        for(int y = 0; y < grid.rows; y++)
        {
            for(int x = 0; x < grid.columns; x++)
            {
                GameObject go = Instantiate(gridTile, transform);
                go.GetComponent<Transform>().position = new Vector2(x - (grid.columns - grid.horizontalOffset), y - (grid.rows - grid.verticalOffSet));
                go.name = "X: " + x + "Y: " + y;
                avaliablePoints.Add(go.transform.position);
                go.SetActive(false);
            }
        }

        GetComponentInParent<ObjectRoomSpawner>().InitializeObjectSpawning();
    }

}
