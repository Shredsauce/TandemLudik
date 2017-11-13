using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameControl : MonoBehaviour {

	public static GameControl Instance;

	public GameObject obstaclePrefab;

	public float curvature = 0.001f;

	[Range(0f, 1f)] public float curveAmount = 0f;
	public float minCurvature = 0.0001f;
	public float maxCurvature = 0.03f;

	public static float minDistance = -14f;
	public static float maxDistance = -10f;

	public Shader curvedShader;

	public static float averageCompletion = 0f;

	public float pedalMultiplier = 0.0005f;

	[Range(0f, -5f)] public float scrollSpeed = 0f;

	void Awake () {
		Instance = this;
	}

	void Update () {
		curvature = Mathf.Lerp(minCurvature, maxCurvature, curveAmount);

		if (Input.GetKeyDown(KeyCode.O)) {
			AddObstacle ();
		}


		GameControl.averageCompletion = GetAverageCompletion();
	}

	private void AddObstacle () {
		Instantiate((GameObject)obstaclePrefab);
	}

	private float GetAverageCompletion () {
		float ac = 0f;
		for (int i = 0; i < Bike.bikes.Count; i++) {
			ac += Bike.bikes[i].completion;
		}
		return ac / Bike.bikes.Count;
	}
}
