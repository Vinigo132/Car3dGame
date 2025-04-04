using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int score = 0;
    public Text scoreText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore()
    {
        score++;
        scoreText.text = "Score: " + score;
        Debug.Log("Score Atual: " + score);
    }
}
