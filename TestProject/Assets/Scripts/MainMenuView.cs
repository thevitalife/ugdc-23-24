using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour
{
    [SerializeField]
    private Button playButton;

    [SerializeField]
    private Button exitButton;

    private void Awake()
    {
        playButton.onClick.AddListener(Play);
        exitButton.onClick.AddListener(Exit);
    }

    public void Play()
    {
        MainMenuSceneController.Instance.LoadDoorScene();
    }

    public void Exit()
    {
        Application.Quit();
    }
}
