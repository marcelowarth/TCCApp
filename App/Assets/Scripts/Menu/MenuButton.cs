using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public TaskManager taskManager;
    public GameObject levelButtonParent;

    public void GoToSelection()
    {
        if (taskManager.conveyorLevar.bReceivedAllHardware)
        {
            SaveGameFile file = SaveGameSystem.LoadGame(SceneManager.GetActiveScene().name);
            if (file != null)
            {
                file.stars = 0;
                file.stars++;
                if(taskManager.taskCount <= taskManager.maxTaskCount)
                {
                    file.stars++;
                }
                if(taskManager.taskExecutions <= taskManager.maxTaskExecutions)
                {
                    file.stars++;
                }
                SaveGameSystem.SaveGame(file, SceneManager.GetActiveScene().name);
            }
            else
            {
                SaveGameFile newFile = new SaveGameFile();
                newFile.stars = 0;
                newFile.stars++;
                if (taskManager.taskCount <= taskManager.maxTaskCount)
                {
                    newFile.stars++;
                }
                if (taskManager.taskExecutions <= taskManager.maxTaskExecutions)
                {
                    newFile.stars++;
                }
                SaveGameSystem.SaveGame(newFile, SceneManager.GetActiveScene().name);
            }

        }
        SceneManager.LoadScene("LevelSelection");
    }
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void DeleteAllSaveGame()
    {
        LevelButton[] allSaves = levelButtonParent.GetComponentsInChildren<LevelButton>();
        for (int i = 0; i < allSaves.Length; i++)
        {
            SaveGameSystem.DeleteSaveGame(allSaves[i].sceneName);
            allSaves[i].ReloadSave();
        }
    }
}
