using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	public Easing.Type easing;

	void Start () {
		Camera.main.FadeIn(5f, easing);
	}

	void Update () {
	
	}
}
