using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class star_manager : MonoBehaviour {
	public float generate_speed=1f;
	public float generate_speed_acceleration=0.05f;
	public GameObject star;
	float Timer=0;
	float left;
	float right;
	public float min_force;
	public float max_force;

	void Start(){
		left=Camera.main.ScreenToWorldPoint(Vector3.zero).x;	
		right=Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,0,0)).x;	

	}
	void generate(){
		Vector3 pos=new Vector3(Random.Range(left,right),transform.position.y,0);
		GameObject n=Instantiate(star,pos,transform.rotation);
		n.GetComponent<Rigidbody2D> ().velocity = Vector2.down * Random.Range (min_force, max_force);
	}
	void FixedUpdate () {
		Timer+=Time.deltaTime;
		generate_speed += generate_speed_acceleration * Time.deltaTime;
		if(Timer>1/generate_speed){
			Timer=0;
			generate();
		}
	}
}
