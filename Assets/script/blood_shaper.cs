using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class blood_shaper : MonoBehaviour {
	public float max_width=13.6f;
	RectTransform recter;
	void Start(){
		recter=gameObject.GetComponent<RectTransform>();
		Vector2 pos = Vector2.zero;
		pos.y-=transform.parent.GetComponent<RectTransform>().sizeDelta.y/2+0.5f;
		transform.parent.GetComponent<RectTransform>().anchoredPosition=pos;
		max_width = recter.sizeDelta.x;
		recter.anchoredPosition = new Vector2 (max_width/18,0);
	}
	public void shape_blood(float blood,float max_blood){
		float width_=blood/max_blood*max_width;
		recter.sizeDelta=new Vector2(width_,gameObject.GetComponent<RectTransform>().sizeDelta.y);
	}
}
