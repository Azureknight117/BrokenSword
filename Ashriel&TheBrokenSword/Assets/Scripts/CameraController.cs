using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    public Room currentRoom;
    public float moveSpeed;

    private void Awake()
    {
        instance = this;
    }


    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
    }

    void UpdatePosition()
    {
        if(currentRoom == null)
        {
            return;
        }

        Vector3 targetPos = GetCameraTargetPositon();

        transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * moveSpeed);
    }

    Vector3 GetCameraTargetPositon()
    {
        if (currentRoom == null)
        {
            return Vector3.zero;
        }

        Vector3 targetPos = currentRoom.GetRoomCenter();
        targetPos.z = transform.position.z;
        return targetPos;
    }

    public bool IsSwitchingScene()
    {
        return transform.position.Equals(GetCameraTargetPositon()) == false;
    }
}
