using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer))]
public class GroundScroll : MonoBehaviour {
	//scroll main texture based on time

	private float offset;
	private float rotate;

	private Renderer rend;

	void Start () {
		rend = GetComponent<Renderer>();
	}

	void Update (){
		offset += GameControl.Instance.scrollSpeed * Time.deltaTime * 0.5f;

        rend.material.SetTextureOffset ("_MainTex", new Vector2(0, offset));
	}
}
