using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingController : MonoBehaviour
{
    public GameObject wings; // 引用翅膀模型的GameObject
    public float flyingHeight = 10f; // 触发显示翅膀的飞行高度

    private void Start()
    {
        // 确保开始时翅膀是隐藏的
        HideWings();
    }

    private void Update()
    {
        // 获取Player的高度
        float playerHeight = transform.position.y;

        // 根据高度判断是否显示翅膀
        if (playerHeight >= flyingHeight)
        {
            ShowWings();
        }
        else
        {
            HideWings();
        }
    }

    // 显示翅膀的方法
    private void ShowWings()
    {
        if (wings != null)
        {
            wings.SetActive(true);
        }
    }

    // 隐藏翅膀的方法
    private void HideWings()
    {
        if (wings != null)
        {
            wings.SetActive(false);
        }
    }
}