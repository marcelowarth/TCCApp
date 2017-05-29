using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelButton : MonoBehaviour
{
    public string sceneName;
    public GameObject[] stars;
    private SaveGameFile saveFile;
    private void Start()
    {                      
        stars[0].SetActive(false);
        stars[1].SetActive(false);
        stars[2].SetActive(false);
        saveFile = SaveGameSystem.LoadGame(sceneName);
        UpdateButtonStars();
    }   

    void UpdateButtonStars()
    {
        if (saveFile != null)
        {
            for (int i = 0; i < saveFile.stars; i++)
            {
                stars[i].SetActive(true);
            }
        }
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(sceneName);
    }
    public void ReloadSave()
    {
        stars[0].SetActive(false);
        stars[1].SetActive(false);
        stars[2].SetActive(false);
        saveFile = SaveGameSystem.LoadGame(sceneName);
        UpdateButtonStars();
    }
}
