using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    public Button restartButton;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    public List<GameObject> targets;
    public GameObject titleScreen;
    private float spawnRate = 1.0f;
    private int score;
    public bool isGameActive;

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);  
            Instantiate(targets[index]);
        }
        
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score " + score;
    }

    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        titleScreen.gameObject.SetActive(false);
        isGameActive = true;
        score = 0;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);

    }

    public void GameOver()
    {
        
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
