using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatHit : MonoBehaviour {

	public AnimationClip hitAnim;
    Animation anim;

	void Start() {
        anim = GetComponent<Animation>();
    }

	public void hit ()
	{
		//Instantiate(ball, ballPos);
		anim.clip = hitAnim;
        anim.Play(); 
	}




	
}
