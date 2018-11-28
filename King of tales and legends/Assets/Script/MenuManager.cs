using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuManager : MonoBehaviour {

    public void ButtonVsIa ()
    {
        GameObject gameManagerGameObject = GameObject.Find("GameManager");
        GameManager gameManager = gameManagerGameObject.GetComponent<GameManager>();
        gameManager.SetGameMode(0);
        SceneManager.LoadScene("BattleScene", LoadSceneMode.Single);
    }

    public void ButtonLocal ()
    {
        GameObject gameManagerGameObject = GameObject.Find("GameManager");
        GameManager gameManager = gameManagerGameObject.GetComponent<GameManager>();
        gameManager.SetGameMode(1);
        SceneManager.LoadScene("CharactersSelectionScene", LoadSceneMode.Single);
    }
    
    public void ButtonOnline ()
    {
        GameObject gameManagerGameObject = GameObject.Find("GameManager");
        GameManager gameManager = gameManagerGameObject.GetComponent<GameManager>();
        gameManager.SetGameMode(2);
        SceneManager.LoadScene("CharactersSelectionScene", LoadSceneMode.Single);
    }
}
