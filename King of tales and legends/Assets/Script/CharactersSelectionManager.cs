using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharactersSelectionManager : MonoBehaviour {
    public Button[] blist;
    public Text[] tlist;
    private int player_number;

	// Use this for initialization
	void Awake () {
        player_number = 1;
	}

    public void SelectCharacter(int button_number)
    {
        if(player_number == 1)
        {
            Button b = blist[button_number];
            ColorBlock cb = b.colors;
            cb.disabledColor = Color.blue;
            b.colors = cb;
            b.interactable = false;

            GameObject gameManagerGameObject = GameObject.Find("GameManager");
            GameManager gameManager = gameManagerGameObject.GetComponent<GameManager>();
            gameManager.SetPlayerOneCharacter(button_number);

            tlist[0].enabled = false;
            tlist[1].enabled = true;
        }
        else if (player_number == 2)
        {
            Button b = blist[button_number];
            ColorBlock cb = b.colors;
            cb.disabledColor = Color.red;
            b.colors = cb;
            b.interactable = false;

            GameObject gameManagerGameObject = GameObject.Find("GameManager");
            GameManager gameManager = gameManagerGameObject.GetComponent<GameManager>();
            gameManager.SetPlayerTwoCharacter(button_number);

            Button start = blist[8];
            start.interactable = true;

            tlist[0].enabled = true;
        }
        player_number++;
    }

    public void StartBattle()
    {
        SceneManager.LoadScene("BattleScene", LoadSceneMode.Single);
    }
}
