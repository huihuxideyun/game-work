using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    private void Update()
    {
        if (player != null)
        {
            // 设置摄像机的位置为玩家位置加上偏移
            transform.position = player.position + offset;

            // 让摄像机朝向玩家的正前方
            transform.forward = player.forward;
        }
    }
}

