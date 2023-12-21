using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float moveSpeed = 5f; // 移动速度
    public float rotationSpeed = 100f; // 旋转速度
    public Camera followCamera; // 跟随的摄像机

    void Update()
    {
        // 获取水平和垂直轴向输入（左右、前后、A、D、W、S键）
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // 根据输入计算移动方向
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // 如果有输入，则旋转角色朝向移动方向
        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        // 移动角色
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

        // 更新摄像机位置
        UpdateCameraPosition();
    }

    void UpdateCameraPosition()
    {
        // 获取角色当前位置
        Vector3 playerPosition = transform.position;

        // 计算摄像机在角色后方的位置（可以根据需求调整偏移）
        Vector3 cameraOffset = new Vector3(0f, 5f, 8f); // 调整摄像机高度和离角色距离
        Vector3 cameraPosition = playerPosition + cameraOffset;

        // 平滑移动摄像机位置
        followCamera.transform.position = Vector3.Lerp(followCamera.transform.position, cameraPosition, 0.1f);
    }
}




