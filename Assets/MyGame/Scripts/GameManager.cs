using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private const string SceneName = "MainScene";
    private const string SceneName1 = "MenuScene";
    public static GameManager instance;
    public GameObject gameOverPanel;
    public Text scoreText;
    private int score;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void GameOver()
    {
        ObstacleSpawner.instance.gameOver = true;
        GameManager.StopScrolling(this);
        gameOverPanel.SetActive(true);
    }

    private static void StopScrolling(GameManager instance)
    {
        TextureScroll[] scrollingObjects = FindObjectsOfType<TextureScroll>();

        foreach (TextureScroll item in scrollingObjects)
        {
            item.scroll = false;
            Debug.Log(item.name);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneName);
    }

    public void Menu()
    {
        SceneManager.LoadScene(SceneName1);
    }

    public void IncrementScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
