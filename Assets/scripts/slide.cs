using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slide : MonoBehaviour
{
 Vector2 startPos, endPos, direction;
 float touchTimeStart, touchTimeFinish, timeInterval;
	public GameObject sixEffect;

	public bool swiped = false;

 [Range (0.05f, 1f)]
 public float throwForce = 50f;

	public AnimationClip hit;
    Animation anim;

	void Start() {
        anim = GetComponent<Animation>();
    }

	void FixedUpdate(){
  if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {
	   touchTimeStart = Time.time;
	   startPos = Input.GetTouch (0).position;
	   swiped = false;
  }
  if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Ended) {
   touchTimeFinish = Time.time;
	timeInterval = touchTimeFinish - touchTimeStart;﻿
   endPos = Input.GetTouch (0).position;
   direction = startPos - endPos;

   swiped = true;

			anim.clip = hit;
            anim.Play(); 
   //GetComponent<Rigidbody2D> ().AddForce (-direction / timeInterval * throwForce);

		
  }

		if (Input.GetKeyDown(KeyCode.W)){

			
            anim.clip = hit;
            anim.Play();        
        }
 }



	void OnCollisionEnter2D (Collision2D col)
	{
//		if (col.gameObject.CompareTag ("ball") && !BallHit.bowled) {
//
//			Invoke ("restart", 4f);
//
//			Debug.Log ("bat");
//
//			if (swiped) {
//				Debug.Log ("bbat Hit");
//
//				col.gameObject.GetComponent<Rigidbody2D> ().AddForce (direction * throwForce);
//			}
//			else
//				col.gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.up*throwForce);
//
//			Camera.main.GetComponent<AudioSource> ().Play ();
//
//			GameObject.Destroy (Instantiate (sixEffect), 4);
//
//		}

	}

	void restart() {
//		yield return new WaitForSeconds(4f);

		GameObject.Find("Environment").GetComponent<GameControl>().Restart();
	}
}﻿