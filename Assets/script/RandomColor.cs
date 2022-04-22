using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class RandomColor : MonoBehaviour {
	SpriteRenderer spriteRenderer;
	public Color[] colors;
	[Range(1.0f, 10.0f)]
	public float multiplierMax = 3f;
	Vector3 initialScale;
	bool activated=false;
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		initialScale = transform.localScale;
		int colorSelected = Random.Range (0, colors.Length);
		if (colors.Length > 0) {
			spriteRenderer.color = colors[colorSelected];
		}
		transform.localScale = initialScale * Random.Range(1f, multiplierMax);
	}
	void OnBecameVisible(){
		activated=true;
	}
	void OnBecameInvisible(){
		if(activated)
			Destroy(gameObject);
	}
}
