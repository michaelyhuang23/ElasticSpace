using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_scale : MonoBehaviour {
	public float width;
	public float height;
	void Awake () {
		gameObject.GetComponent<RectTransform> ().sizeDelta = new Vector2 (width*Screen.width,height*Screen.height);
	}
}
