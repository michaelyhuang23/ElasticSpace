using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class move_control : MonoBehaviour {
	public float Speed=40f;
	bool use_gyro;
	float right_x=0,left_x=0,up_y=0,down_y=0;
	float x,y;
	public float giro_x,giro_y;
	float current_x,current_y;
	//public GameObject text;
	public float unvariable_x=5,unvariable_y=5;
	Vector2 velocity;
	Gyroscope gyro_;
	void Start(){
		use_gyro = SystemInfo.supportsGyroscope;
		use_gyro = false;
		if (use_gyro) {
			gyro_ = Input.gyro;
			gyro_.enabled = true;
		}

			//text.GetComponent<Text> ().text = "no gyroscope";
		right_x=Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,0,0)).x;
		left_x=Camera.main.ScreenToWorldPoint(new Vector3(0,0,0)).x;
		up_y=Camera.main.ScreenToWorldPoint(new Vector3(0,Screen.height,0)).y;
		down_y=Camera.main.ScreenToWorldPoint(new Vector3(0,0,0)).y;
		giro_x = 0;
		giro_y = 0;
		/*standard_gyro_y=gyro_.attitude.eulerAngles.y;
		if (standard_gyro_y > 180)
			standard_gyro_y -= 360;*/
	}
	void Update () {
		if (use_gyro) {
			//giro_y = gyro_.rotationRateUnbiased.y; 
			//giro_x = gyro_.rotationRateUnbiased.x;
			//y = -giro_x * Speed*unvariable_x;
			//x = giro_y * Speed*unvariable_x;
			//giro_y = gyro_.attitude.eulerAngles.y;
			giro_x +=gyro_.rotationRateUnbiased.y*Time.deltaTime;
			giro_y +=gyro_.rotationRateUnbiased.x*Time.deltaTime;
			/*if (giro_x > 180)
				giro_x -= 360;*/
			//if (giro_y > 180)
			//	giro_y -= 360;
			y = -giro_y*Speed*unvariable_x;
			x = giro_x * Speed*unvariable_y;
			//x = Mathf.Cos (giro_x * Mathf.Deg2Rad) * Speed;
			//y = Mathf.Cos (giro_y * Mathf.Deg2Rad) * Speed;
			//text.GetComponent<Text> ().text = giro_x+" "+gyro_.rotationRateUnbiased.y*Time.deltaTime;
		}else{
			x=Input.GetAxis("Horizontal")*Speed*unvariable_x;
			y=Input.GetAxis("Vertical")*Speed*unvariable_y;
			//x = 0;
			//y = 0;
		}
		current_x=Mathf.Clamp(transform.position.x,left_x,right_x);
		current_y=Mathf.Clamp(transform.position.y,down_y,up_y);
		if (current_x != transform.position.x || current_y != transform.position.y) {
			transform.position = new Vector3 (current_x, current_y, 0);
			gameObject.GetComponent<Rigidbody2D> ().velocity=Vector2.zero;
		}
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (x, y) * Time.deltaTime;
		/*velocity = gameObject.GetComponent<Rigidbody2D> ().velocity;
		if(x/Mathf.Abs(x)!=velocity.x/Mathf.Abs(velocity.x) && y/Mathf.Abs(y)!=velocity.y/Mathf.Abs(velocity.y))
			gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (x, y) * Time.deltaTime;
		else
		gameObject.GetComponent<Rigidbody2D> ().velocity += new Vector2 (x, y) * Time.deltaTime;*/
	}
}
