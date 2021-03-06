﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    
    //Carrega década a ser mostrada
    public void LoadDecade(string name)
    {
        SceneManager.LoadScene(name);
    }
	
	public void LoadLevel(string name) {
        SceneManager.LoadScene(name);
	}

    //Carrega fase para desenvolvimento
    public void LoadLevelWithInfo(string name)
    {
        // TODO: buscar valores de entrada, saida, problema, variáveis e comandos iniciais
        SceneManager.LoadScene(name);
    }

    public void QuitRequest() {
		Application.Quit();
	}
	
	public void LoadNextScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
