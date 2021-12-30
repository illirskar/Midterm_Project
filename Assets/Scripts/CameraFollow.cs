using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public Vector3 CameraOffset;
    private float CameraSpeed = 1f;

    public static CameraFollow Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void Update()
    {
        MoveCamera();
    }

    public void MoveCamera()
    {
        Vector3 TargetPos = player.transform.position + CameraOffset;
        transform.position = Vector3.MoveTowards(transform.position, TargetPos, CameraSpeed);
    }
}
