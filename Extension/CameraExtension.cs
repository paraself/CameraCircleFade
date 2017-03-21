using UnityEngine;
using System.Collections;

public static class CameraExtension {

	static CameraCircleFade camFade (Camera cam) {
		CameraCircleFade cf = cam.GetComponent<CameraCircleFade>();
		if (cf) return cf; else {
			return cam.gameObject.AddComponent<CameraCircleFade>();
		}
	}

	public static void FadeIn(this Camera cam, float duration, Easing.Type easing = Easing.Type.CubicInOut) {
		CameraCircleFade cf = camFade(cam);
		cf.Tween(0f,1.2f,duration,x => cf.radius = x, easing);
	}

	public static void FadeOut(this Camera cam, float duration, Easing.Type easing = Easing.Type.CubicInOut) {
		CameraCircleFade cf = camFade(cam);
		cf.Tween(1.2f,0f,duration,x => cf.radius = x, easing);
	}

}

