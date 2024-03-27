using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSceneController : MonoBehaviour
{
    public static MainMenuSceneController Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void LoadDoorScene()
    {
        SceneManager.LoadScene("DoorScene");
    }
}
