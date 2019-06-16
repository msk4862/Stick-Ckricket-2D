using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwBall : MonoBehaviour {

	private float ballSpeed;

	public bool collisionFound;

	public Sprite outStumps;

	public GameObject bowledEffect; 

	public GameObject sixEffect;
	public GameObject fourEffect;
	public GameObject threeEffect;
	public GameObject twoEffect;
	public GameObject oneEffect;

	static int restartTime = 300;


	public static bool bowled = false;

	Vector2[] ballDir = {new Vector2(-1.7f, -0.5f), new Vector2(-1.5f, -0.3f), new Vector2(-1.7f, -0.4f)};

	// Use this for initialization
	void Start () {

		restartTime = 300;
		ballSpeed = Random.Range(550f, 600f);
		collisionFound  = false;

		GetComponent<Rigidbody2D>().AddForce(ballDir[Random.Range(0, 3)] * ballSpeed);	//Random.Range(0, 3)
	}
	
	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.CompareTag ("stumps") && !collisionFound) {
			collisionFound = true;

			Debug.Log ("stumps");
			bowled = true;
			Invoke ("restart", 4);

			//GameControl.score -= 4;

			Camera.main.GetComponent<AudioSource> ().Play ();
				
			col.gameObject.GetComponent<SpriteRenderer> ().sprite = outStumps;

			//Destroy(this.gameObject);
			this.gameObject.SetActive (false);

			GameObject.Destroy (Instantiate (bowledEffect), 3f);


		} else if (col.gameObject.CompareTag ("zone") && !collisionFound) {
			collisionFound = true;

			Debug.Log ("zone");
			Invoke ("restart", 4);
			this.gameObject.SetActive (false);
			//Destroy(this.gameObject);

		} 
		else if(col.gameObject.CompareTag("bat") && !collisionFound) {
			Debug.Log ("bat");

			this.GetComponent<Rigidbody2D>().AddForce(ballSpeed* new Vector2(1, 1));

		}

		else if (col.gameObject.CompareTag ("one") && !collisionFound) {
			collisionFound = true;

			this.gameObject.SetActive (false);

			Debug.Log ("boundry");
			Invoke ("restart", 4);

			GameObject.Find("Environment").GetComponent<AudioSource>().Play ();
			GameObject.Destroy (Instantiate (oneEffect), 3f);

			GameControl.score += 1;
			//Destroy(this.gameObject);

		}
		else if (col.gameObject.CompareTag ("two") && !collisionFound) {
			collisionFound = true;

			this.gameObject.SetActive (false);

			Debug.Log ("boundry");
			Invoke ("restart", 4);

			GameObject.Find("Environment").GetComponent<AudioSource>().Play ();
			GameObject.Destroy (Instantiate (twoEffect), 3f);

			GameControl.score += 2;

			//Destroy(this.gameObject);

		}
		else if (col.gameObject.CompareTag ("three") && !collisionFound) {
			collisionFound = true;

			this.gameObject.SetActive (false);

			Debug.Log ("boundry");
			Invoke ("restart", 4);

			GameObject.Find("Environment").GetComponent<AudioSource>().Play ();
			GameObject.Destroy (Instantiate (threeEffect), 3f);


			GameControl.score += 3;
	//Destroy(this.gameObject);

		}

		else if (col.gameObject.CompareTag ("four") && !collisionFound) {
			collisionFound = true;

			this.gameObject.SetActive (false);

			Debug.Log ("boundry");
			Invoke ("restart", 4);

			GameObject.Find("Environment").GetComponent<AudioSource>().Play ();
			GameObject.Destroy (Instantiate (fourEffect), 3f);

			//Destroy(this.gameObject);

			GameControl.score += 4;


		}
		else if (col.gameObject.CompareTag ("six") && !collisionFound) {
			collisionFound = true;

			this.gameObject.SetActive (false);

			Debug.Log ("boundry");
			Invoke ("restart", 4);

			GameObject.Find("Environment").GetComponent<AudioSource>().Play ();
			GameObject.Destroy (Instantiate (sixEffect), 3f);

			//Destroy(this.gameObject);
			GameControl.score += 6;

		}

		  /*else if (col.gameObject.CompareTag ("bat")){
			Debug.Log ("Nothing");
			Invoke ("restart", 5);
			this.gameObject.SetActive (false);

		}*/
	}


	void Update() {

		restartTime--;
		if(restartTime <= 0 && collisionFound == false) {
			this.gameObject.SetActive (false);
			restartTime = 300;
			 
			Invoke ("restart", 2);

		}
	}

	void restart() {
//		yield return new WaitForSeconds(4f);

		restartTime = 300;
		GameObject.Find("Environment").GetComponent<GameControl>().Restart();
	}

}
