using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class user_info{
	public string name;
	public int highest_score;
}
public class entering_gui : MonoBehaviour {
	public float width,height,font1;
	public static int highest_score;
	public GUISkin skin0;
	public GUISkin skin1;
	public GUISkin skin2;
	public GUISkin skin3;
	public GUISkin skin4;
	public GUISkin skin5;
	public user_info[] accounts= new user_info[10];
	public static user_info using_account;
	user_info exchanging_account;
	int item;
	int j;
	int length=0;
	string name_;
	bool OnWin=false;
	public static bool awakened=false;
	void Start(){
		name_ = "Please Enter Your Name Here";
		using_account = new user_info ();
		exchanging_account = new user_info ();
		for (int k = 0; k < 10; k++) {
			accounts [k] = new user_info ();
		}
		length = 0;
		OnWin = false;
		item = 0;
		if (awakened) {
			using_account.name = printer.account.name;
			using_account.highest_score = (int)(printer.account.highest_score);
		}
		awakened = true;
	
		for(int i=0;i<10;i++){
			if(PlayerPrefs.HasKey("name"+i) && PlayerPrefs.HasKey("highest_score"+i)){ 
				length++;
				accounts [i].name = PlayerPrefs.GetString ("name"+i);
				accounts [i].highest_score = PlayerPrefs.GetInt ("highest_score"+i);
				if (accounts[i].name==using_account.name)
					item = i;
			}
		}
		print (item);
		if (using_account.highest_score > accounts [item].highest_score) {
			accounts [item].highest_score = using_account.highest_score;
		} else
			using_account.highest_score = accounts [item].highest_score;
		arrenge ();
		
	}
	void find_account(){
		for (int n = 0; n < length; n++) {
			if (accounts[n].name==using_account.name)
				item = n;
		}
	}
	void arrenge(){
		for (int m = 0; m <length; m++) {
			for (j = m + 1; j < length; j++) {
				if (accounts [m].highest_score < accounts [j].highest_score) {
					exchanging_account = accounts [m];
					accounts [m] = accounts [j];
					accounts [j] = exchanging_account;
				}
			}
		}
		find_account ();
	}
	void LoadAccount(){
		using_account = accounts [item];
		for (int g=0; g < length; g++) {
			PlayerPrefs.SetString ("name"+g,accounts[g].name);
			PlayerPrefs.SetInt ("highest_score"+g,accounts[g].highest_score);
		}
	}
	void OnWinOn(int id){
		bool invalid = false;
		GUILayout.BeginVertical();
		name_=GUILayout.TextField (name_);
		if (GUILayout.Button ("Done")) {
			if (name_.Length > 0) {
				for (int h = 0; h < length; h++) {
					if (accounts [h].name == name_) {
						invalid = true;
						break;
					}
				}
			} else {
				invalid = true;
			}
			if (!invalid) {
				accounts [length].name = name_;
				accounts [length].highest_score = 0;
				item = length;
				length++;
				name_="Please Enter Your Name Here";
				OnWin = false;
			}
		}
		GUILayout.EndVertical ();
	}
	void OnGUI(){
		GUI.skin = skin4;
		if (OnWin)
			GUI.Window (1, new Rect (0, Screen.height / 12, Screen.width, Screen.height / 3), OnWinOn, "Please Enter Your Name");
		else {
			GUILayout.BeginHorizontal ();
			GUI.skin = skin0;
			GUI.skin.button.fontSize = (int)(Screen.width * font1);
			GUILayout.BeginVertical ();
			if (GUILayout.Button ("quit")) {
				LoadAccount ();
				Application.Quit ();
			}
			GUILayout.EndVertical ();
			GUI.skin = skin2;
			GUILayout.Space (Screen.width / 7f);
			GUILayout.BeginVertical ();
			GUILayout.Space (Screen.height / 9f);
			GUILayout.Label ("Elastic Space  --V2.0");
			GUILayout.Space (Screen.height / 12f);
			GUI.skin = skin5;
			for (int l = 0; l < length; l++) {
				if (l != item) {
					if (GUILayout.Button (accounts [l].name + " :  " + accounts [l].highest_score)) {
						item = l;
						using_account = accounts [item];
					} 
				}
				else {
					GUI.skin = skin4;
					GUILayout.Label (accounts[l].name+"  score: "+accounts[l].highest_score);
					GUI.skin = skin5;
				}
			}
			if (length<10 && GUILayout.Button ("create new account")) {
				OnWin = true;
			}

			if (length > 0 && GUILayout.Button ("delete last account")) {
				length--;
				PlayerPrefs.DeleteKey ("name"+length);
				PlayerPrefs.DeleteKey ("highest_score"+length);
			}
			GUI.skin = skin1;
			GUILayout.Space (Screen.height / 16f);
			if (GUILayout.Button ("PLAY")) {
				LoadAccount ();
				Application.LoadLevel ("small_playing_scene");
			}
			GUILayout.Space (Screen.height / 16f);
			GUI.skin = skin3;
			GUILayout.Label ("Made by Michael Huang");
			GUILayout.EndVertical ();
			GUILayout.EndHorizontal ();
		}
	}
}
