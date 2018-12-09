using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuManager : MonoBehaviour {

    public void ButtonPlay ()
    {
        GameObject gameManagerGameObject = GameObject.Find("GameManager");
        GameManager gameManager = gameManagerGameObject.GetComponent<GameManager>();
        gameManager.SetGameMode(1);
        SceneManager.LoadScene("CharactersSelectionScene", LoadSceneMode.Single);
    }
    
    public void ButtonQuit ()
    {
        Application.Quit();
    }
}
