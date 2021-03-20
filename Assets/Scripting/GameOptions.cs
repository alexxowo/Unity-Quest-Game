using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOptions : MonoBehaviour
{
    public GameObject startGameWindow;
    public void OpenGameWindow() => startGameWindow.SetActive(true);

    public void CloseGameWindow() => startGameWindow.SetActive(false);

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void exitGame() => Application.Quit();
}
