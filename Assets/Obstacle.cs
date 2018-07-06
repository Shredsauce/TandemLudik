using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	private float startDistance = 8f;
	private float destroyDistance = -18f;

	private int lane;

	void Awake () {
		lane = UnityEngine.Random.Range(0, 6);

		transform.position = new Vector3(
			lane - 3f,
			0f,
			startDistance
		);

	}

	void Update () {
		transform.Translate(
			0f,
			0f,
			GameControl.Instance.scrollSpeed * Time.deltaTime
		);

		if (transform.position.z < destroyDistance) {
			Destroy(this.gameObject);
		}
	}
}
