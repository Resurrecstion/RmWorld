
using UnityEngine;

public class SimpleRoomPlacer : MonoBehaviour
{
    public GameObject roomPrefab;
    public Vector2 roomSize = new Vector2(16, 9);

    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            Vector2 pos = new Vector2(i * roomSize.x, 0);
            var room = Instantiate(roomPrefab, pos, Quaternion.identity);

            Transform leftDoor = room.transform.Find("DoorLeft");
            Transform rightDoor = room.transform.Find("DoorRight");

            if (i == 0)
            {
                rightDoor?.gameObject.SetActive(true);
            }
            else if (i == 1)
            {
                leftDoor?.gameObject.SetActive(true);
                rightDoor?.gameObject.SetActive(true);
            }
            else if (i == 2)
            {
                leftDoor?.gameObject.SetActive(true);
            }

            leftDoor?.GetComponent<Animator>()?.SetBool("isOpen", true);
            rightDoor?.GetComponent<Animator>()?.SetBool("isOpen", true);
        }
    }
}
