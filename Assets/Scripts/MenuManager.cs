using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Canvas menu;
    public Canvas scores;
    public Button startBtn;
    public Button exitBtn;
    public Button scoresBtn;
    public Button backToMenu;

    private void Start()
    {
        scoresBtn.onClick.AddListener(ShowScores);
        backToMenu.onClick.AddListener(ShowMenu);
    }

    private void ShowScores()
    {
        menu.gameObject.SetActive(false);
        scores.gameObject.SetActive(true);
    }

    private void ShowMenu()
    {
        menu.gameObject.SetActive(true);
        scores.gameObject.SetActive(false);
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