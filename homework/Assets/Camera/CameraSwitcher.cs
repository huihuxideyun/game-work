using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;

    void Start()
    {
        // 开始时只启用第一个摄像机
        camera1.enabled = true;
        camera2.enabled = false;
    }

    void Update()
    {
        // 在这里检测切换条件，例如按下某个键或在特定的游戏事件发生时
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            // 切换摄像机的状态
            SwitchCameras();
        }
    }

    void SwitchCameras()
    {
        // 切换摄像机的启用状态
        camera1.enabled = !camera1.enabled;
        camera2.enabled = !camera2.enabled;
    }
}
