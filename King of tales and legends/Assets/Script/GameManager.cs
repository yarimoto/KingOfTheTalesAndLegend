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
}
