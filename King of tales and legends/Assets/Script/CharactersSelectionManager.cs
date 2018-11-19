using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersSelectionManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject gameManagerGameObject = GameObject.Find("GameManager");
        GameManager gameManager = gameManagerGameObject.GetComponent<GameManager>();
        int mode = gameManager.GetGameMode();
		Debug.Log(mode);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
