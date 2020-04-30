using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    public DungeonGeneratorData dungeonGenerationData;

    private List<Vector2Int> dungeonRooms;
    bool spawnedTreasure = false;

    private void Start()
    {
        dungeonRooms = DungeonCrawlerController.GenerateDungeon(dungeonGenerationData);
        SpawnRooms(dungeonRooms);
    }

    private void SpawnRooms(IEnumerable<Vector2Int> rooms)
    {
        RoomController.instance.LoadRoom("Start", 0, 0);
        foreach (Vector2Int roomLocation in rooms)
        {
            if (!spawnedTreasure && roomLocation == dungeonRooms[dungeonRooms.Count / 2] && roomLocation != Vector2Int.zero)
            {
                RoomController.instance.LoadRoom("Treasure", roomLocation.x, roomLocation.y);
                spawnedTreasure = true;
            }
            else
            {
                RoomController.instance.LoadRoom(RoomController.instance.GetRandomRoomName(), roomLocation.x, roomLocation.y);
            }

        }
    }
}
