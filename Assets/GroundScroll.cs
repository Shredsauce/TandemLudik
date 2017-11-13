using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer))]
public class GroundScroll : MonoBehaviour {
	//scroll main texture based on time

	[SerializeField] private float scrollSpeed = 0.5f;
	private float offset;
	private float rotate;

	private Renderer rend;

	void Start () {
		rend = GetComponent<Renderer>();
	}

	void Update (){
		offset += (Time.deltaTime*scrollSpeed)/10.0f;
		rend.material.SetTextureOffset ("_MainTex", new Vector2(0, offset * rend.material.mainTextureScale.y));
		scrollSpeed = GameControl.Instance.scrollSpeed;
	}
}
