using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Bike : MonoBehaviour {
	public static List<Bike> bikes = new List<Bike>();
	[HideInInspector] public int bikeId;

	// Key to press to mimick pedal revolution. For testing
	[SerializeField] private KeyCode bikeKeyCode;
	// Amount between 0 and 1 completed
	[Range(0f, 1f)] public float completion;

	private float deltaTime = 0f;
	private float lastTime = 0f;

	public float decaySpeed = 2f;

	public float currentSpeed = 0f;

	// Set up reference to the bike and its id in the list
	void OnEnable () {
		this.bikeId = bikes.Count;
		bikes.Add(this);
	}

	// Remove the bike and reset the bike ids for the other bikes
	void OnDisable () {
		bikes.Remove(this);
		// Reset the bike ids
		for (int i = 0; i < bikes.Count; i++) {
			bikes[i].bikeId = i;
		}
	}

	void Update () {
		// Set the z distance. Average according to own completion and that of other bikes
		this.transform.position = new Vector3(
			this.transform.position.x,
			this.transform.position.y,
			Mathf.Lerp(GameControl.minDistance, GameControl.maxDistance, 0.5f + completion - GameControl.averageCompletion)
		);
			
		if (this == bikes[bikeId] && Input.GetKeyDown(bikeKeyCode)) {
			deltaTime = Time.time - lastTime;


			float rpm = 1 / deltaTime;
			currentSpeed = rpm;



			lastTime = Time.time;
		}

		currentSpeed = Mathf.Lerp(currentSpeed, 0f, Mathf.Clamp01(deltaTime) * Time.deltaTime * decaySpeed);
		currentSpeed = (float)Mathf.RoundToInt(currentSpeed * 100) * 0.01f;


		completion += currentSpeed * GameControl.Instance.pedalMultiplier;

		if (completion > 1f) {
			Debug.Log(string.Format("{0} wins!", bikes[bikeId]));

			foreach (Bike bike in bikes) {
				bike.completion = 0f;
				bike.currentSpeed = 0f;
			}
		}
	}
}
