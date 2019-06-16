using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameControl : MonoBehaviour {


	public GameObject player;


	public GameObject ball;
	private float ballSpeed = 100f;

	public GameObject stumps;
	public Sprite Normalstumps;
	public Transform ballPos;

	public static int score = 0;

	public static int totalBalls = 0; 

	public static int over = 0;  
	public static int balls = 0; 

	public GameObject endScreen;
	public Text endscoreUI;

	public Text scoreUI;
	public Text overUI;

	public bool isGameOver = false;

	public GameObject teamScreen;

	public GameObject shirtColor;
	public Sprite ind;
	public Sprite pak;
	public Sprite nz;
	public Sprite sa;

	private  static int TEAM;
	private  static int OVERS;

	// Use this for initialization
	void Start () {

		player.SetActive(false);

		endScreen.SetActive(false);
		teamScreen.SetActive(true);
		over  = 0;
		balls = 0;
		totalBalls = 0;

		OVERS = 1;
		score = 0;

		//Invoke("Restart", 4);
	}

	public void Restart ()
	{
		totalBalls += 1;

		if (totalBalls <= OVERS*6) {

			Debug.Log ("restart");


			over = totalBalls / 6;
			balls = totalBalls % 6;

			stumps.GetComponent<SpriteRenderer> ().sprite = Normalstumps;

			Instantiate (ball);
			

		} else {
			isGameOver = true;
			endscoreUI.text = "YOUR RUNS : " + score;
			player.SetActive(false);
			endScreen.SetActive(true);

		}

	}

	void Update ()

	{	
		scoreUI.text = "RUNS: " + score;
		overUI.text = "OVERS: " + over + "." + balls;


	}

	public void team (int team)
	{

		Invoke("Restart", 4);

		TEAM = team;



		switch(TEAM) {
		case 0: shirtColor.GetComponent<SpriteRenderer>().sprite =  ind;
					break; 

		case 1: shirtColor.GetComponent<SpriteRenderer>().sprite =  pak;
					break; 

		case 2: shirtColor.GetComponent<SpriteRenderer>().sprite =  nz;
					break; 

		case 3: shirtColor.GetComponent<SpriteRenderer>().sprite =  sa;
					break; 

		}


		teamScreen.SetActive(false);
		player.SetActive(true);


	}

	public void Exit() {
		Application.Quit();
	}

}
