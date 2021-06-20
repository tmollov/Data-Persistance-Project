using DefaultNamespace;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public string playerName = "";

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SaveScore(int score)
    {
        SaveManager.SaveScore(playerName, score);
    }
}