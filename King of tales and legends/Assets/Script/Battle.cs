using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour {

    float time;
    int timeInt;
    int phase;
    List<int> player1_action;
    List<int> player2_action;
    public int TestLife;
    int player1_life;
    int player2_life;
    bool end;
    List<List<String>> damageTable;
    bool defeat;
    public Sprite[] bg;

    public Text timeText;
    public Text player1_hp;
    public Text player2_hp;
    public Text gameOverText;

    // Use this for initialization
    void Start () {
        time = 5;
        phase = 0;
        end = true;
        player1_action = new List<int>();
        player2_action = new List<int>();
        player1_life = player2_life = TestLife;
        player1_hp.text = player2_hp.text = TestLife.ToString();
        damageTable = new List<List<string>>();
        damageTable.Add(new List<string>() { "Draw", "Win", "Lose" });
        damageTable.Add(new List<string>() { "Lose", "Draw", "Win" });
        damageTable.Add(new List<string>() { "Win", "Lose", "Draw" });
        defeat = false;
        UnityEngine.Random.InitState(System.DateTime.Now.Millisecond);
        GameObject UI_BackGround = GameObject.Find("bg");
        UI_BackGround.GetComponent<Image>().sprite = bg[UnityEngine.Random.Range(0, 3)];
        GameObject UI_player1_HPBar = GameObject.Find("P1_HPBar");
        UI_player1_HPBar.GetComponent<Image>().fillAmount = 1;
        GameObject UI_player2_HPBar = GameObject.Find("P2_HPBar");
        UI_player2_HPBar.GetComponent<Image>().fillAmount = 1;

    }
	
	// Update is called once per frame
	void Update () {
        timeInt = Mathf.RoundToInt(time);
        var timeSpan = TimeSpan.FromSeconds(timeInt);
        timeText.text = (string.Format("{0:D2}:{1:D2}", (int)timeSpan.TotalMinutes, timeSpan.Seconds));
        if (time >= 0 && defeat == false)
            time -= Time.deltaTime;
        else
        {
            Debug.Log("time < 0");
            if (phase.Equals(0))
            {
                player1_action.Clear();
                player2_action.Clear();
                end = true;
                Debug.Log("pahse 0");
                
                phase = 1;
                time = 3f;

                StartCoroutine(key_listener1());
                StartCoroutine(key_listener2());
                //Debug.Log("pahse 0 END");
            }
            else if (phase.Equals(1))
            {
                Debug.Log("phase 1");

                end = false;
                fill_actions();
                DamageOutput();
                phase = 0;
                time = 5f;
                //Debug.Log("[ " + player1_action[0].ToString() + ", " + player1_action[1].ToString() + ", " + player1_action[2].ToString() + " ]");
                //Debug.Log("[ " + player2_action[0].ToString() + ", " + player2_action[1].ToString() + ", " + player2_action[2].ToString() + " ]");
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
                player1_action.Add(0);
                state++;
                key = true;
            }
            if (Input.GetKeyDown(KeyCode.Z) && !key)
            {
                player1_action.Add(1);
                state++;
                key = true;
            }
            if (Input.GetKeyDown(KeyCode.E) && !key)
            {
                player1_action.Add(2);
                state++;
                key = true;
            }
            yield return null;
        }
        yield return null;
    }

    IEnumerator key_listener2()
    {
        int state = 0;
        while (state != 3 && end)
        {
            bool key = false;
            if (Input.GetKeyDown(KeyCode.K))
            {
                player2_action.Add(0);
                state++;
                key = true;
            }
            if (Input.GetKeyDown(KeyCode.L) && !key)
            {
                player2_action.Add(1);
                state++;
                key = true;
            }
            if (Input.GetKeyDown(KeyCode.M) && !key)
            {
                player2_action.Add(2);
                state++;
                key = true;
            }
            yield return null;
        }
        yield return null;
    }
    public void say_ha()
    {
        Debug.Log("Ha!");
    }

    void fill_actions()
    {
        while (player1_action.Count < 3)
            player1_action.Add(-1);
        while (player2_action.Count < 3)
            player2_action.Add(-1);
    }

    void DamageOutput()
    {
        int index = 0;
        foreach (int i in player1_action)
        {
            if (i == -1)
            {
                if (player2_action[index] == -1)
                {
                    player1_life -= 10;
                    player2_life -= 10;
                }
                else
                    player1_life -= 15;
            }
            else if (player2_action[index] == -1)
                player2_life -= 15;
            else
            {
                if (damageTable[i][player2_action[index]].Equals("Draw"))
                {
                    player1_life -= 15;
                    player2_life -= 15;
                }
                else if (damageTable[i][player2_action[index]].Equals("Win"))
                    player2_life -= 20;
                else
                    player1_life -= 20;
            }
        }

        if (player2_life <= 0)
        {
            gameOverText.text = "Player 1 WINS !";
            player2_hp.text = "0";
            GameObject UI_player2_HPBar = GameObject.Find("P2_HPBar");
            UI_player2_HPBar.GetComponent<Image>().fillAmount = 0.2f;
            defeat = true;
        }
        else if (player1_life < 0)
        {
            gameOverText.text = "Player 2 WINS !";
            player1_hp.text = "0";
            GameObject UI_player1_HPBar = GameObject.Find("P1_HPBar");
            UI_player1_HPBar.GetComponent<Image>().fillAmount = 0.2f;
            defeat = true;
        }
        else
        {
            player1_hp.text = player1_life.ToString();
            GameObject UI_player1_HPBar = GameObject.Find("P1_HPBar");
            UI_player1_HPBar.GetComponent<Image>().fillAmount = ((0.8f / 100) * player1_life) + 0.2f;
            player2_hp.text = player2_life.ToString();
            GameObject UI_player2_HPBar = GameObject.Find("P2_HPBar");
            UI_player2_HPBar.GetComponent<Image>().fillAmount = ((0.8f / 100) * player2_life) + 0.2f;
        }
        

    }
}
