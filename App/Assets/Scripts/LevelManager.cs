﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

	private float loadNextLevelAfter = 2.5f;
	
	void Start () {
		if(SceneManager.GetActiveScene().buildIndex == 0) {
			Invoke ("LoadNextLevel", loadNextLevelAfter);
		}
	}

    //Carrega década a ser mostrada
    public void LoadDecade(string name)
    {
        SceneManager.LoadScene(name);
    }
	
    //Carrega fase para desenvolvimento
	public void LoadLevel(int id) {
        // TODO: buscar valores de entrada, saida, problema, variáveis e comandos iniciais
        SceneManager.LoadScene("90 Game");
	}
	
	public void QuitRequest() {
		Application.Quit();
	}
	
	public void LoadNextScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
