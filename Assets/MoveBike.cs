using UnityEngine;
using System.Collections;

public class MoveBike : MonoBehaviour {

	public float minTime = 0.2f;
	public float maxTime = 1f;

	public float minSpeed = -0.4f;
	public float maxSpeed = 0.4f;

	private float oldSpeed;

	void Start () {
		StartCoroutine(MoveOverTime());
	}
	
	void Update () {
		
	}

	private IEnumerator MoveOverTime () {

		float timer = Random.Range(minTime, maxTime);
		float speed = Random.Range(minSpeed, maxSpeed);

		float timerDiv = 1 / timer;

		while (timer > 0) {
			timer -= Time.deltaTime;
			this.transform.Translate(0, 0, Mathf.Lerp(speed, oldSpeed, 1 - Mathf.InverseLerp(0, 1, timer)) * Time.deltaTime);
			yield return null;
		}
		
		oldSpeed = speed;

		StartCoroutine(MoveOverTime());
	}
}
