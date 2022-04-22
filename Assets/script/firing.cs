using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class firing : MonoBehaviour {
	public Transform[] bullets=new Transform[2];
	public float force;
	public float time_spawn;
	public float error_fix;
	public AudioSource player;
	public AudioClip fire;
	float timer=0;
	void FixedUpdate(){
		timer+=Time.deltaTime;
		if(Input.touchCount>0 && timer>time_spawn && Input.GetTouch(0).phase==TouchPhase.Began){
			player.PlayOneShot (fire);
			timer=0;
			Vector3 mousepos=Vector3.zero;
		    mousepos=Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x,Input.GetTouch(0).position.y,0));
			Vector2 direction=new Vector2(mousepos.x-transform.position.x,mousepos.y-transform.position.y).normalized;
			transform.up=direction;
	    	int ran=(int)(Random.Range(0,2));
			Transform n=Instantiate(bullets[ran],transform.position+transform.TransformDirection(Vector3.up)*error_fix,transform.rotation);
	     	n.gameObject.GetComponent<Rigidbody2D>().AddForce(direction*force);
		}
		if (Input.GetMouseButton(0) && timer>time_spawn) {
			player.PlayOneShot (fire);
			timer=0;
			Vector3 mousepos=Vector3.zero;
			mousepos=Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,0));
			Vector2 direction=new Vector2(mousepos.x-transform.position.x,mousepos.y-transform.position.y).normalized;
			transform.up=direction;
			int ran=(int)(Random.Range(0,2));
			Transform n=Instantiate(bullets[ran],transform.position+transform.TransformDirection(Vector3.up)*error_fix,transform.rotation);
			n.gameObject.GetComponent<Rigidbody2D>().AddForce(direction*force);
		}
	}
}
