using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;

public class PlayfabManager : MonoBehaviour
{
    [Header("UI")]
    public Text messageText;
    public InputField emailInput;
    public InputField passwordInput;

    private GameManager gameManager;
    private string playFabTitleID = "FDACF";  // 替换为您的PlayFab Title ID
    public Transform player;
    public static PlayfabManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        SceneManager.sceneLoaded += OnSceneLoaded; // 注册场景加载完毕的回调
    }

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        PlayFabSettings.TitleId = playFabTitleID;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            UploadPlayerData();
        }
    }

    public void SetPlayer(Transform newPlayer)
    {
        player = newPlayer;
    }

    public void RegisterButton()
    {
        if (passwordInput.text.Length < 6)
        {
            messageText.text = "密码太短！";
            return;
        }

        var request = new RegisterPlayFabUserRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSucess, OnError);
    }

    void OnRegisterSucess(RegisterPlayFabUserResult result)
    {
        messageText.text = "RegisterSucess";
    }

    public void LoginButton()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }

    void OnLoginSuccess(LoginResult result)
    {
        messageText.text = "Logged in!";
        SceneManager.LoadScene("TEWCPL_Scene"); // 加载新场景
    }

    // 场景加载完毕时的回调方法
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        LoadPlayerData();
    }

    private void LoadPlayerData()
    {
        var request = new GetUserDataRequest();
        PlayFabClientAPI.GetUserData(request, OnDataReceived, OnError);
    }

    private void OnDataReceived(GetUserDataResult result)
    {
        if (result.Data != null)
        {
            if (result.Data.ContainsKey("Health"))
            {
                int health = int.Parse(result.Data["Health"].Value);
                gameManager.health = health;
            }

            if (result.Data.ContainsKey("Score"))
            {
                int score = int.Parse(result.Data["Score"].Value);
                gameManager.score = score;
            }
            if (result.Data.ContainsKey("Position_X") && result.Data.ContainsKey("Position_Y") && result.Data.ContainsKey("Position_Z"))
            {
                float posX = float.Parse(result.Data["Position_X"].Value);
                float posY = float.Parse(result.Data["Position_Y"].Value);
                float posZ = float.Parse(result.Data["Position_Z"].Value);
                player.position = new Vector3(posX, posY, posZ);
            }
            if (result.Data.ContainsKey("Rotation_X") && result.Data.ContainsKey("Rotation_Y") && result.Data.ContainsKey("Rotation_Z"))
            {
                float rotX = float.Parse(result.Data["Rotation_X"].Value);
                float rotY = float.Parse(result.Data["Rotation_Y"].Value);
                float rotZ = float.Parse(result.Data["Rotation_Z"].Value);
                player.rotation = Quaternion.Euler(rotX, rotY, rotZ);
            }
        }
    }

    void OnError(PlayFabError error)
    {
        messageText.text = error.ErrorMessage;
        Debug.Log(error.GenerateErrorReport());
    }

    private void UploadPlayerData()
    {
        int YourHealthVariable = gameManager.health;
        int YourScoreVariable = gameManager.score;
        Vector3 playerPosition = player.position;
        Vector3 playerRotation = player.eulerAngles;

        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                { "Position_X", playerPosition.x.ToString() },
                { "Position_Y", playerPosition.y.ToString() },
                { "Position_Z", playerPosition.z.ToString() },
                { "Rotation_X", playerRotation.x.ToString() },
                { "Rotation_Y", playerRotation.y.ToString() },
                { "Rotation_Z", playerRotation.z.ToString() },
                { "Health", YourHealthVariable.ToString() },
                { "Score", YourScoreVariable.ToString() }
            }
        };

        PlayFabClientAPI.UpdateUserData(request, OnDataUploadSuccess, OnDataUploadFailure);
    }

    private void OnDataUploadSuccess(UpdateUserDataResult result)
    {
        Debug.Log("Player data uploaded successfully!");
    }

    private void OnDataUploadFailure(PlayFabError error)
    {
        Debug.LogError("Player data upload failed: " + error.ErrorMessage);
    }
}
