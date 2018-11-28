using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManagerLocal : MonoBehaviour {



    int player1_pv;
    List<int> player1_action;
    int player2_pv;
    List<int> player2_action;
    float timer;
    int phase;
    public Text timeText;
    float time = 90;
    int timeInt;
    bool end;
    int defeat;

    // Use this for initialization
    void Start () {
        /*GameObject gameManagerGameObject = GameObject.Find("GameManager");
        GameManager gameManager = gameManagerGameObject.GetComponent<GameManager>();
        int mode = gameManager.GetGameMode();
        Debug.Log(mode);*/

         player1_pv = 100;
         player1_action = new List<int>(3);
        player2_pv = 100;
         player2_action = new List<int>(3);
        defeat = -1;
        timer = 5f;
        phase = 0;
        end = true;
    }
	
	// Update is called once per frame
	void Update () {
        phase = 0;
        /*timeInt = Mathf.RoundToInt(time);
        var timeSpan = TimeSpan.FromSeconds(timeInt);
        timeText.text = (string.Format("{0:D2}:{1:D2}", (int)timeSpan.TotalMinutes, timeSpan.Seconds));
        if (time >= 0)
        {
            time -= Time.deltaTime;
        }*/
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            defeat = 42;
        }
        Debug.Log(defeat);
        
        if (defeat == -1)   
        {
            timeInt = Mathf.RoundToInt(timer);
            var timeSpan = TimeSpan.FromSeconds(timeInt);
            timeText.text = (string.Format("{0:D2}:{1:D2}", (int)timeSpan.TotalMinutes, timeSpan.Seconds));
            Debug.Log(phase);
            if (time >= 0 && timeInt >= 0)
                timer -= Time.deltaTime;
            else
            {
                
                if (phase.Equals(0))
                {
                    end = true;
                    Debug.Log("pahse 0");

                        Debug.Log("1");
                        phase = 1;
                        timer = 3;
                        Debug.Log("DING");

                        StartCoroutine(key_listener1());
                        StartCoroutine(key_listener2());
                }
                Debug.Log("pahse 0 END");
                if (phase.Equals(1))
                {
                    Debug.Log("phase 1");
                
                        end = false;
                        Debug.Log("1");
                        phase = 0;
                        timer = 5;
                        Debug.Log(player1_action.ToString());
                        Debug.Log(player2_action.ToString());
                }

            }
        }
        
    }

    IEnumerator key_listener1()
    {
        int state = 0;
        Debug.Log("co");
        while (state != 3 && end)
        {
            Debug.Log("WHILE");
            bool key = false;
            if (Input.GetKeyDown(KeyCode.A))
            {
                player1_action[state] = 1;
                state++;
                key = true;
            }
            if (Input.GetKeyDown(KeyCode.Z) && !key)
            {
                player1_action[state] = 2;
                state++;
                key = true;
            }
            if (Input.GetKeyDown(KeyCode.E) && !key)
            {
                player1_action[state] = 3;
                state++;
                key = true;
            }
        }
        yield return null;
    }

    IEnumerator key_listener2()
    {
        int state = 0;
        while (state != 3 && timer > 0)
        {
            bool key = false;
            if (Input.GetKeyDown(KeyCode.K))
            {
                player2_action[state] = 1;
                state++;
                key = true;
            }
            if (Input.GetKeyDown(KeyCode.L) && !key)
            {
                player2_action[state] = 2;
                state++;
                key = true;
            }
            if (Input.GetKeyDown(KeyCode.M) && !key)
            {
                player2_action[state] = 3;
                state++;
                key = true;
            }
        }
        yield return null;
    }
}
