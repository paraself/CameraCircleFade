using UnityEngine;
using System.Collections;
using System;

public static class MonoBehaviourExtension  {

	public static Coroutine Tween (this MonoBehaviour self, float start, float end, float duration,Action<float> action) {
		return self.StartCoroutine (_Tween (start, end, duration, action));
	}

	public static Coroutine Tween (this MonoBehaviour self, float start, float end, float duration,Action<float> action , Easing.Type easingType) {
		return self.StartCoroutine (_Tween (start, end, duration, action , null, easingType));
	}

	public static Coroutine Tween (this MonoBehaviour self, float start, float end, float duration,Action<float> action , Action onCompleteDelegate ) {
		return self.StartCoroutine (_Tween (start, end, duration, action, onCompleteDelegate));
	}

	public static Coroutine Tween (this MonoBehaviour self, float start, float end, float duration,Action<float> action , Action onCompleteDelegate , Easing.Type easingType) {
		return self.StartCoroutine (_Tween (start, end, duration, action, onCompleteDelegate,easingType));
	}
		
	static IEnumerator _Tween ( float s, float e,float d, Action<float> a,Action onCompleteDelegate = null,Easing.Type easingType = Easing.Type.Linear) {
		if (a == null) yield break;
		float time = 0f;
		float t = 0f;

		if (easingType != Easing.Type.Linear) {
			float t0;
			Func<float,float> interpolation;
			Easing.interpolation.TryGetValue (easingType,out interpolation);

			do {
				t = time / d;
				t0 = interpolation(t);
				a (Mathf.Lerp (s, e, t0));
				time += Time.deltaTime;
				yield return null;
			} while (time < d);
		} else {
			do {
				t = time / d;
				//Debug.Log(Mathf.Lerp (s, e, t));
				a (Mathf.Lerp (s, e, t));
				time += Time.deltaTime;
				yield return null;
			} while (time < d);
		
		}

		a (e);
		if (onCompleteDelegate != null) onCompleteDelegate (); 
	}


}
