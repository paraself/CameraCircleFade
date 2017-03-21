using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class CameraCircleFade : MonoBehaviour {

	[Range(0f,1.2f)]
	public float radius;
	float _radius;
	Material _mtl;
	Material mtl {
		get{
			if (_mtl) return _mtl; 
			else {
				_mtl = new Material(Shader.Find("Hidden/Circle"));
				return _mtl;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (_radius != radius) {
			mtl.SetFloat("_Radius",radius);
			// Debug.Log("Setting radius to " + radius);
			_radius = radius;
		}
	}

	void OnRenderImage ( RenderTexture src, RenderTexture dst) {
		Graphics.Blit(src, dst, mtl);
	}
}



