using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animator_ : MonoBehaviour {
	public Animator animator;
	public void explode(){
		animator.SetTrigger ("explode");
		Destroy (gameObject, 3f);
	}
}
