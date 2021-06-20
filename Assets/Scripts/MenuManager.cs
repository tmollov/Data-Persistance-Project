using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Canvas menu;
    public Button startBtn;
    public Button exitBtn;
    public Button scoresBtn;

    private void Start()
    {
        scoresBtn.onClick.AddListener(ShowScores);
    }

    public void ShowScores()
    {
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    public void HandleInputChange(TMP_InputField changed)
    {
        if (changed.text.Length > 2)
        {
            GameManager.Instance.playerName = changed.text;
            EnableStartButton();
        }
        else
        {
            DisableStartButton();
        }
    }

    private void EnableStartButton()
    {
        startBtn.interactable = true;
    }

    private void DisableStartButton()
    {
        startBtn.interactable = false;
    }
}