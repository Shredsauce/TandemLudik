using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameControl : MonoBehaviour {

	public GameControl Instance;

	public float curvature = 0.001f;

	[Range(0f, 1f)] public float curveAmount = 0f;
	public float minCurvature = 0.0001f;
	public float maxCurvature = 0.03f;

	public Shader curvedShader;

	private List<Material> materials = new List<Material>();

	void Awake () {
		Instance = this;
	}

	void Start () {
		Renderer[] renderers = FindObjectsOfType<Renderer>();
		for (int i = 0; i < renderers.Length; i++) {
			if (renderers[i].material.shader == curvedShader) {
				materials.Add(renderers[i].material);
			}
		}

	}
	
	void Update () {
		curvature = Mathf.Lerp(minCurvature, maxCurvature, curveAmount);

		for (int i = 0; i < materials.Count; i++) {
			materials[i].SetFloat("_Curvature", curvature);
		}
	}
}
