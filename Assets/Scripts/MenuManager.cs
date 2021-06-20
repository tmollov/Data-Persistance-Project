using System.Linq;
using DefaultNamespace;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Canvas menu;
    public Canvas scores;
    public Button startBtn;
    public Button exitBtn;
    public Button scoresBtn;
    public Button backToMenu;

    public TMP_Text[] TopPlayerTexts;

    private void Start()
    {
        scoresBtn.onClick.AddListener(ShowScores);
        backToMenu.onClick.AddListener(ShowMenu);
        exitBtn.onClick.AddListener(ExitGame);
        startBtn.onClick.AddListener(StartGame);
    }

    private void ShowScores()
    {
        var tops = SaveManager.GetTopScores();
        for (int i = 0; i < TopPlayerTexts.Length; i++)
        {
            TopPlayerTexts[i].text = $"{i + 1}. {tops.ElementAt(i).Key} {tops.ElementAt(i).Value} ";
        }

        menu.gameObject.SetActive(false);
        scores.gameObject.SetActive(true);
    }

    private void ShowMenu()
    {
        menu.gameObject.SetActive(true);
        scores.gameObject.SetActive(false);
    }

    private void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    private void StartGame()
    {
        SceneManager.LoadScene("main");
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