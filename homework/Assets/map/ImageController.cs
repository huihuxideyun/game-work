using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageController : MonoBehaviour
{
    // Start is called before the first frame update
    public RawImage targetImage;  // 你的图像
    
    private bool isTabPressed = false;

    void Update()
    {
        // 检测Tab键的按下和松开
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isTabPressed = true;
        }

        if (Input.GetKeyUp(KeyCode.Tab))
        {
            isTabPressed = false;
        }

        // 根据Tab键的状态设置图像的显示和隐藏
        if (isTabPressed)
        {
            ShowImage();
        }
        else
        {
            HideImage();
        }
    }

    void ShowImage()
    {
        // 设置图像为可见
        if (targetImage != null)
        {
            targetImage.enabled = true;
        }
    }

    void HideImage()
    {
        // 设置图像为不可见
        if (targetImage != null)
        {
            targetImage.enabled = false;
        }
    }
 }
