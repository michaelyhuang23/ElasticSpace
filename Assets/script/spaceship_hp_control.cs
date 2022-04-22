using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class spaceship_hp_control : MonoBehaviour {
	[Range(0.0f, 1000.0f)]
	public float max_blood;
	public float blood;
	Rigidbody2D rigid;
	public float blood_minus=0.1f;
	public blood_shaper blooder;
	public GameObject blooder_holder;
	public float hp_bag;
	public GameObject turret;
	public GameObject explosive;
	public GameObject printer_;
	public AudioSource player;
	public AudioClip explosion;
	// Use this for initialization
	void Start () {
		rigid=gameObject.GetComponent<Rigidbody2D>();
		blood=max_blood;
		blooder=blooder_holder.GetComponent<blood_shaper>();
	}
	IEnumerator disappear(){
		gameObject.GetComponent<SpriteRenderer>().enabled=false;
		printer_.GetComponent<printer> ().enabled = false;
		turret.SetActive(false);
		explosive.GetComponent<animator_> ().explode ();
		gameObject.GetComponent<PolygonCollider2D>().enabled=false;
		gameObject.GetComponent<move_control>().enabled=false;
		gameObject.GetComponent<Rigidbody2D>().bodyType=RigidbodyType2D.Kinematic;
		gameObject.GetComponent<Rigidbody2D>().velocity=Vector2.zero;
		yield return new WaitForSeconds(5.0f);
		Camera.main.gameObject.GetComponent<Exiter>().Exit ();
		gameObject.SetActive(false);
	}
	public void End(){
		player.PlayOneShot (explosion);
		StartCoroutine(disappear());
	}
	void OnCollisionEnter2D(Collision2D collision){
		GameObject collider=collision.collider.gameObject;
		if(collider.tag=="Planeta" || collider.tag=="bullet"){
			blood-=collision.relativeVelocity.magnitude*(rigid.mass+collider.GetComponent<Rigidbody2D>().mass)*blood_minus;
			if(blood<0){
				blood=0;
			}
			blooder.shape_blood(blood,max_blood);
			if(blood==0)End();
		}
	}

}
