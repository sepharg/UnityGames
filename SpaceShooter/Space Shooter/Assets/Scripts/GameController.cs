using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float _waveWait;

    public GUIText scoreText;
    public GUIText restartText;
    public GUIText gameOverText;
    private bool gameOver;
    private bool restart;

    private int score;

    void Update()
    {
        if (restart && Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                var hazard = hazards[Random.Range(0, hazards.Length)];
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait); // Coroutine debe devolver IEnumerator.
            }
            yield return new WaitForSeconds(_waveWait);

            if (gameOver)
            {
                restartText.text = "Press ´R´ for Restart";
                restart = true;
                break;
            }
        }
    }

    // Use this for initialization
	void Start ()
	{
	    restartText.text = "";
	    gameOverText.text = "";
        UpdateScore();
	    StartCoroutine(SpawnWaves());
	}

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score " + score;
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over";
        gameOver = true;
    }
}
