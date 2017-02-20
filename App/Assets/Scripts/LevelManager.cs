using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public float loadNextLevelAfter = 2.5f;
	
	void Start () {
		if(SceneManager.GetActiveScene().buildIndex == 0) {
			Invoke ("LoadNextLevel", loadNextLevelAfter);
		} else if(loadNextLevelAfter <= 0f) {
			Debug.Log("Use positive number on Load Next Level After!");
		}
	}
	
	public void LoadLevel(string name) {
        SceneManager.LoadScene(name);
	}
	
	public void QuitRequest() {
		Application.Quit();
	}
	
	public void LoadNextScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
