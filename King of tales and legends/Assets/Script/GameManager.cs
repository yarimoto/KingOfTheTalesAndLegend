using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    //Game Manager instantiate
    public static GameManager instance = null;

    //Settings Variable
    private int gamemode = -1;

    //Player variables
    private int player_one = -1;
    private int player_two = -1;
    private int background = -1;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public int GetGameMode()
    {
        return this.gamemode;
    }

    public void SetGameMode(int gameMode)
    {
        this.gamemode = gameMode;
    }

    public int GetPlayerOneCharacter()
    {
        return this.player_one;
    }

    public void SetPlayerOneCharacter(int character)
    {
        this.player_one = character;
    }

    public int GetPlayerTwoCharacter()
    {
        return this.player_two;
    }

    public void SetPlayerTwoCharacter(int character)
    {
        this.player_two = character;
    }
}
