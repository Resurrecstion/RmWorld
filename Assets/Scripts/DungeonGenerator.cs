using UnityEngine;
using System.Collections.Generic;



public class DungeonGenerator : MonoBehaviour
{
    public GameObject roomPrefab;
    public int numberOfRooms = 10;
    public Vector2 roomSize = new Vector2(16, 9);
    public Transform roomParent;

    private Dictionary<Vector2, GameObject> rooms = new();
    private List<Vector2> directions;

    void Start()
    {
        directions = new List<Vector2>{
            Vector2.up * roomSize.y,
            Vector2.down * roomSize.y,
            Vector2.left * roomSize.x,
            Vector2.right * roomSize.x
        };
        Generate();
    }

    void Generate()
    {
        Vector2 pos = Vector2.zero;
        SpawnRoom(pos);
        for (int i = 1; i < numberOfRooms; i++)
        {
            Vector2 newPos;
            do {
                Vector2 dir = directions[Random.Range(0, directions.Count)];
                newPos = pos + dir;
            } while (rooms.ContainsKey(newPos));

            SpawnRoom(newPos);
            pos = newPos;
        }
        ConnectDoors();
    }

    void SpawnRoom(Vector2 pos)
    {
        var room = Instantiate(roomPrefab, pos, Quaternion.identity, roomParent);
        rooms[pos] = room;
    }

    void ConnectDoors()
    {
        foreach (var kv in rooms)
        {
            Vector2 pos = kv.Key;
            GameObject room = kv.Value;
            foreach (var dir in directions)
            {
                if (rooms.ContainsKey(pos + dir))
                {
                    EnableDoor(room, dir);
                }
            }
        }
    }

    void EnableDoor(GameObject room, Vector2 dir)
    {
        string name = dir == Vector2.up ? "DoorTop"
            : dir == Vector2.down ? "DoorBottom"
            : dir == Vector2.left ? "DoorLeft"
            : "DoorRight";

        var door = room.transform.Find(name);
        if (door != null)
        {
            door.gameObject.SetActive(true);
            var ctrl = door.GetComponent<DoorController>();
            ctrl?.SetOpen(true);
        }
    }
}
