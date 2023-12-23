using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    private void LateUpdate()
    {
        if (target != null)
        {
            // 计算摄像机目标位置
            Vector3 targetPosition = target.position + offset;

            // 平滑地移动摄像机到目标位置
            transform.position = Vector3.Lerp(transform.position, targetPosition, 0.1f);
        }
    }
}
