using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    [SerializeField] private Text speedText;
    [SerializeField] private HallEffect hallEffect;

	void Start () {
		
	}
	
	void Update () {
        speedText.text = string.Format("Speed: {0}", hallEffect.smoothedRpm.ToString("F"));
        GameControl.Instance.scrollSpeed = -Mathf.LerpUnclamped(0, 5f, hallEffect.smoothedRpm * 0.025f);
	}
}
