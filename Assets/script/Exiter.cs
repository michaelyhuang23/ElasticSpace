using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exiter : MonoBehaviour {
	public float width,height,win_width,win_height,altitude,font1;
	float win_actual_width,win_actual_height;
	float sensitivity=50f,sensitivity2=50f;
	public GUISkin skin1;
	public GUISkin skin2;
	bool on_=true;
	bool exit_=false;
	bool done=false;
	int score;
	int highest_score;
	move_control move;
	AudioSource audio_player;
	void Start(){
		on_ = true;
		move = GameObject.FindGameObjectWithTag ("Player").GetComponent<move_control> ();
		audio_player = gameObject.GetComponent<AudioSource> ();
	}
	public void Exit(){
		exit_ = true;
		audio_player.Stop ();
		score = (int)(printer.account.highest_score);
		highest_score = entering_gui.using_account.highest_score;
		if (score > highest_score)
			highest_score = score;
	}
	void OnWinOpen(int id){
		GUILayout.BeginVertical ();
		GUI.skin = skin1;
		GUI.skin.label.fontSize = (int)(win_actual_width * font1);
		GUI.skin.button.fontSize = (int)(win_actual_width * font1);
		GUILayout.Space (win_actual_height/8);
		GUILayout.Label ("Score:"+score);
		GUILayout.Space (win_actual_height/8);
		GUILayout.Label ("HighestScore:"+highest_score);
		GUILayout.Space (win_actual_height/8);
		if (GUILayout.Button ("Exit"))
			Application.LoadLevel ("entering_scene");
		GUILayout.EndVertical ();
	}
	void OnGUI(){
		GUI.skin = skin2;
		if (exit_) {
			win_actual_width = (Screen.width * (1 - win_width)) / 2;
			win_actual_height = Screen.height * altitude;
			GUI.Window (0, new Rect (win_actual_width, win_actual_height, Screen.width * win_width, Screen.height * win_height), OnWinOpen, "Failure");
		} else {
			GUI.skin.button.fontSize = (int)(width * Screen.width*font1);
			if (on_) {
				if (GUI.Button (new Rect (0, 0, width * Screen.width, height * Screen.height), "Pause")) {
					Time.timeScale = 0;
					audio_player.Stop ();
					on_ = false;
				}
				if (!done) {
					move.unvariable_x = sensitivity/10f;
					move.unvariable_y = sensitivity2/10f;
					move.giro_x = 0f;
					move.giro_y = 0f;
					done = true;
				}
			} else {
				done = false;
				if (GUI.Button (new Rect (0, 0, width * Screen.width, height * Screen.height), "Start")) {
					Time.timeScale = 1;
					audio_player.Play ();
					on_ = true;
				}
				if (GUI.Button (new Rect (0, height * Screen.height+20f, width * Screen.width, height * Screen.height), "Quit")) {
					Time.timeScale = 1;
					Application.LoadLevel ("entering_scene");
				}
				GUI.Label (new Rect (width * Screen.width * 0.5f, height * 3f * Screen.height + 40f, width * Screen.width*4, height * Screen.height), "Vertical Sensitivity");
				sensitivity=GUI.HorizontalSlider (new Rect (width*Screen.width*0.5f, height * 4f * Screen.height + 40f, 4f * width * Screen.width*2f, height * Screen.height*2), sensitivity, 1f, 200f);
				GUI.Label (new Rect (width * Screen.width * 0.5f, height * 5f * Screen.height + 40f, width * Screen.width*4, height * Screen.height), "Horizontal Sensitivity");
				sensitivity2=GUI.HorizontalSlider (new Rect (width*Screen.width*0.5f, height * 6f * Screen.height + 40f, 4f * width * Screen.width*2f, height * Screen.height*2), sensitivity2, 1f, 200f);
			}
		}

	}
}
