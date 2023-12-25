using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 5f;
    public float flyForce = 2f;  // 飞行时的力度
    public float maxFlyHeight = 10f;  // 最大飞行高度
    private Rigidbody rb;
    private bool isGrounded = true;
    private bool isFlying = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // 长按Q启动飞行
        if (Input.GetKey(KeyCode.Q) && !isGrounded)
        {
            isFlying = true;
            float currentFlyHeight = transform.position.y;
            if (currentFlyHeight < maxFlyHeight)
            {
                rb.AddForce(Vector3.up * flyForce, ForceMode.Acceleration);
            }
        }

        // 松开Q停止飞行
        if (Input.GetKeyUp(KeyCode.Q))
        {
            isFlying = false;
        }

        // 快速下落
        if (!isGrounded && !isFlying)
        {
            rb.AddForce(Vector3.down * (jumpForce * 1.5f), ForceMode.Acceleration);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}