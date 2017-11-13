using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Curved : MonoBehaviour {
	private List<Material> materials = new List<Material>();

	void Start () {
		Renderer[] renderers = GetComponentsInChildren<Renderer>();

		for (int i = 0; i < renderers.Length; i++) {
			for (int j = 0; j < renderers[i].materials.Length; j++) {
				if (renderers[i].materials[j].shader == GameControl.Instance.curvedShader) {
					materials.Add(renderers[i].materials[j]);
				}
			}
		}

		SetCurvature ();
	}

	void Update () {
		SetCurvature ();
	}

	private void SetCurvature () {
		for (int i = 0; i < materials.Count; i++) {
			materials[i].SetFloat("_Curvature", GameControl.Instance.curvature);
		}
	}
}
