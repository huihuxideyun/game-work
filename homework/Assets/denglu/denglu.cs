using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class denglu : MonoBehaviour
{
    public InputField usernameInput;
    public InputField passwordInput;
    // Start is called before the first frame update
 
    public void OnLoginButtonClick()
    {
        
        if ( usernameInput.text=="xhhsa"&& passwordInput.text=="0073070")
        {
            SceneManager.LoadScene("TEWCPL_Scene");
        }
        // Update is called once per frame
        else
        {
            // 登录失败，清空输入框
            usernameInput.text = "";
            passwordInput.text = "";
           
        }
    }
}
