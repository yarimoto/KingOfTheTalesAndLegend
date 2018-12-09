using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour {

    float time;
    float animation_timer;
    int timeInt;
    int phase;
    List<int> player1_action;
    List<int> player2_action;
    public int TestLife;
    public int TestEnergy;
    int player1_life;
    int player2_life;
    int player1_energy;
    int player2_energy;
    bool end;
    List<List<String>> damageTable;
    bool defeat;
    bool battle;
    public Sprite[] bg;
    int index;

    public Text timeText;
    public Text player1_hp;
    public Text player2_hp;
    public Text player1_en;
    public Text player2_en;
    public Text gameOverText;
    public GameObject CBT;
    public Text BattleLog;
    public Scrollbar scroll;

    // Use this for initialization
    void Start () {
        time = 5;
        animation_timer = 0;
        phase = 0;
        end = true;
        index = 0;
        player1_action = new List<int>();
        player2_action = new List<int>();
        player1_life = player2_life = TestLife;
        player1_hp.text = player2_hp.text = TestLife.ToString();
        player1_energy = player2_energy = TestEnergy;
        player1_en.text = player2_en.text = TestEnergy.ToString();
        damageTable = new List<List<string>>();
        damageTable.Add(new List<string>() { "Draw", "Win", "Lose", "Super Lose", "Block" });
        damageTable.Add(new List<string>() { "Lose", "Draw", "Win", "Super Lose", "Block" });
        damageTable.Add(new List<string>() { "Win", "Lose", "Draw", "Super Lose", "Block" });
        damageTable.Add(new List<string>() { "Super Win", "Super Win", "Super Win", "Super Draw", "Win" });
        damageTable.Add(new List<string>() { "Block", "Block", "Block", "Lose", "Block" });
        damageTable.Add(new List<string>() { "Sword Attack", "Magic Attack", "Range Attack", "Super Attack", "Shield" });
        defeat = false;
        battle = false;
        UnityEngine.Random.InitState(System.DateTime.Now.Millisecond);
        GameObject UI_BackGround = GameObject.Find("bg");
        UI_BackGround.GetComponent<Image>().sprite = bg[UnityEngine.Random.Range(0, 3)];
        GameObject UI_player1_HPBar = GameObject.Find("P1_HPBar");
        UI_player1_HPBar.GetComponent<Image>().fillAmount = 1;
        GameObject UI_player2_HPBar = GameObject.Find("P2_HPBar");
        UI_player2_HPBar.GetComponent<Image>().fillAmount = 1;
        GameObject UI_player1_energy = GameObject.Find("P1_energy");
        UI_player1_energy.GetComponent<Image>().fillAmount = 0.3f;
        GameObject UI_player2_energy = GameObject.Find("P2_energy");
        UI_player2_energy.GetComponent<Image>().fillAmount = 0.3f;

    }
	
	// Update is called once per frame
	void Update () {
        if (battle == true)
        {
            if (animation_timer <= 0)
            {
                scroll.value = 0;
                DamageOutput();
                index++;
                scroll.value = 0;
            }
            else
            {
                animation_timer -= Time.deltaTime;
            }
            if (index == 3)
            {
                battle = false;
                animation_timer = 0;
            }
        }
        else if (defeat == false)
        {
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
                    index = 0;
                    battle = true;
                
                phase = 0;
                time = 5f;
                //Debug.Log("[ " + player1_action[0].ToString() + ", " + player1_action[1].ToString() + ", " + player1_action[2].ToString() + " ]");
                //Debug.Log("[ " + player2_action[0].ToString() + ", " + player2_action[1].ToString() + ", " + player2_action[2].ToString() + " ]");
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
            if (Input.GetKeyDown(KeyCode.Tab) && !key)
            {
                if (player1_energy >= 30)
                {
                    player1_action.Add(3);
                    state++;
                    key = true;
                    player1_energy -= 30;
                    player1_en.text = player1_energy.ToString();
                    GameObject UI_player1_energy = GameObject.Find("P1_energy");
                    UI_player1_energy.GetComponent<Image>().fillAmount = ((1f / 100f) * player1_energy);
                }
            }
            if (Input.GetKeyDown(KeyCode.R) && !key)
            {
                if (player1_energy >= 30)
                {
                    player1_action.Add(4);
                    state++;
                    key = true;
                    player1_energy -= 30;
                    player1_en.text = player1_energy.ToString();
                    GameObject UI_player1_energy = GameObject.Find("P1_energy");
                    UI_player1_energy.GetComponent<Image>().fillAmount = ((1f / 100f) * player1_energy);
                }
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
            if (Input.GetKeyDown(KeyCode.I) && !key)
            {
                if (player2_energy >= 30)
                {
                    player1_action.Add(3);
                    state++;
                    key = true;
                    player2_energy -= 30;
                    player2_en.text = player2_energy.ToString();
                    GameObject UI_player2_energy = GameObject.Find("P2_energy");
                    UI_player2_energy.GetComponent<Image>().fillAmount = ((1f / 100f) * player2_energy);
                }
            }
            if (Input.GetKeyDown(KeyCode.J) && !key)
            {
                if (player2_energy >= 30)
                {
                    player1_action.Add(4);
                    state++;
                    key = true;
                    player2_energy -= 30;
                    player2_en.text = player2_energy.ToString();
                    GameObject UI_player2_energy = GameObject.Find("P2_energy");
                    UI_player2_energy.GetComponent<Image>().fillAmount = ((1f / 100f) * player2_energy);
                }
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
        BattleLog.text += "---- ROUND " + index.ToString() + " ----\n";
        int i = player1_action[index];
            if (i == -1)
            {
                if (player2_action[index] == -1)
                {
                BattleLog.text += "Player 1 and Player 2 idle : -10 HP.\n";
                    player1_life -= 10;
                    player2_life -= 10;
                initCBT("-10 HP");
                }
                else
                {
                    player1_life -= 15;
                    player2_energy += 5;
                BattleLog.text += "Player 1 idle : -15 HP\nPlayer 2 gain 5 energy.\n";
            }
            }
            else if (player2_action[index] == -1)
            {
                player2_life -= 15;
                player1_energy += 5;
            BattleLog.text += "Player 1 gain 5 energy\nPlayer 2 idle : -15 HP.\n";
        }
            else
            {
                if (damageTable[i][player2_action[index]].Equals("Draw"))
                {
                    player1_life -= 15;
                    player2_life -= 15;
                BattleLog.text += "Player 1 and Player 2 use " + damageTable[5][i] + " : -15 HP.\n";
            }
                else if (damageTable[i][player2_action[index]].Equals("Win"))
                {
                    player2_life -= 20;
                    player1_energy += 10;
                BattleLog.text += "Player 1 use " + damageTable[5][i] + " - Player 2 use " + damageTable[5][player2_action[index]] + " : Player 1 wins.\nPlayer 1 gains 10 energy.\nPlayer 2 : -20 HP.\n";
            }
                else
                {
                    player1_life -= 20;
                    player2_energy += 10;
                BattleLog.text += "Player 1 use " + damageTable[5][i] + " - Player 2 use " + damageTable[5][player2_action[index]] + " : Player 2 wins.\nPlayer 1 : -20 HP.\nPlayer 2 gains 10 energy.\n";
            }
            }

            if (player1_energy > 100) player1_energy = 100;
            if (player2_energy > 100) player2_energy = 100;
            GameObject UI_player1_energy = GameObject.Find("P1_energy");
            UI_player1_energy.GetComponent<Image>().fillAmount = ((1f / 100f) * player1_energy);
            player1_en.text = player1_energy.ToString();
            GameObject UI_player2_energy = GameObject.Find("P2_energy");
            UI_player2_energy.GetComponent<Image>().fillAmount = ((1f / 100f) * player2_energy);
            player2_en.text = player2_energy.ToString();
        animation_timer = 2f;
        scroll.value = 0;

            if (player2_life <= 0)
            {
                gameOverText.text = "Player 1 WINS !";
                player2_hp.text = "0";
                GameObject UI_player2_HPBar = GameObject.Find("P2_HPBar");
                UI_player2_HPBar.GetComponent<Image>().fillAmount = 0.2f;
                defeat = true;
            battle = false;
                return;
            }
            else if (player1_life < 0)
            {
                gameOverText.text = "Player 2 WINS !";
                player1_hp.text = "0";
                GameObject UI_player1_HPBar = GameObject.Find("P1_HPBar");
                UI_player1_HPBar.GetComponent<Image>().fillAmount = 0.2f;
                defeat = true;
            battle = false;
            return;
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

    void initCBT(string dmg)
    {
        GameObject temp = Instantiate(CBT) as GameObject;
        RectTransform tempRect = temp.GetComponent<RectTransform>();
        temp.transform.SetParent(GameObject.Find("Canvas").transform);
        temp.transform.localPosition = CBT.transform.localPosition;
        temp.transform.localPosition = new Vector3(CBT.transform.localPosition.x + UnityEngine.Random.Range(-10.0f, 10.0f), CBT.transform.localPosition.y, CBT.transform.localPosition.z);
        temp.transform.localScale = CBT.transform.localScale;
        temp.transform.localRotation = CBT.transform.localRotation;

        temp.GetComponent<Text>().text = dmg;
        temp.GetComponent<Animator>().SetTrigger("damage");
        Destroy(temp.gameObject, 2);
    }
}
