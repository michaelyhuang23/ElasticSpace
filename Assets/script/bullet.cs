using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;

public class bullet : MonoBehaviour {
	public float add_score;
	public AudioSource collide_player;
	public AudioClip collide;
	void Start(){
		Destroy(gameObject,5f);
	}
	void OnCollisionEnter2D(Collision2D collision){
		collide_player.PlayOneShot (collide);
		printer.account.highest_score+=collision.relativeVelocity.magnitude*add_score;

	}
}
