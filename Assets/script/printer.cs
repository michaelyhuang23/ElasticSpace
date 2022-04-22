using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class user_information{
	public string name;
	public float highest_score;
}
public class printer : MonoBehaviour {

	public float printer_descend;
	public static user_information account=new user_information();
	public int score_plus=5;
	Text print_text;
	void Start(){
		gameObject.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0,-printer_descend*Screen.height);
		print_text = gameObject.GetComponent<Text> ();
		account = new user_information ();
		account.name = entering_gui.using_account.name;
		account.highest_score = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		account.highest_score += Time.deltaTime * score_plus;
		print_text.text = "Score: " + (int)(account.highest_score);
	}
}
