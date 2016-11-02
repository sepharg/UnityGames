using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public string levelSelect;
	public string mainMenu;

	public bool isPaused;
	public GameObject pauseMenuCanvas;
		
	// Update is called once per frame
	void Update () 
	{
		pauseMenuCanvas.SetActive(isPaused); // if game is paused, show greyed out menu.

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			isPaused = !isPaused;
		}

		Time.timeScale = isPaused ? 0f : 1f;
	}

	public void Resume()
	{
		isPaused = false;
	}

	public void LevelSelect()
	{
		SceneManager.LoadScene (levelSelect);
	}

	public void Quit()
	{
		SceneManager.LoadScene (mainMenu);
	}
}
