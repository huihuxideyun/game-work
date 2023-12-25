using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FLY : MonoBehaviour
{
    public float flightForce = 3f;         // 飞行力
    public float maxFlightHeight = 100f;    // 最大飞行高度
    public float fallSpeed = 10f;          // 下落速度

    private bool isFlying = false;         // 是否正在飞行
    private float currentFlightHeight = 0f; // 当前飞行高度
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 长按F键开始飞行
        if (Input.GetKey(KeyCode.Q) && !isFlying)
        {
            isFlying = true;
        }

        // 在飞行状态下
        if (isFlying)
        {
            // 缓慢地飞行，限制最大飞行高度
            if (currentFlightHeight < maxFlightHeight)
            {
                rb.AddForce(Vector3.up * flightForce, ForceMode.Force);
                currentFlightHeight += Time.deltaTime;
            }
            else
            {
                // 达到最大飞行高度时，开始下落
                isFlying = false;
            }
        }

        // 松开F键时快速下落
        if (Input.GetKeyUp(KeyCode.F))
        {
            isFlying = false;
            currentFlightHeight = 0f;
            rb.velocity = Vector3.down * fallSpeed;
        }
    }
}
