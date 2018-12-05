using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingScenery : MonoBehaviour {

    [SerializeField] private GameObject buildingPrefab;

    private GameObject building;

	
	void Update () {
        if (Input.GetKeyDown(KeyCode.L)) {
            Debug.Log("Load building");

            building = Instantiate(buildingPrefab);
            building.transform.position = new Vector3(2.61f, 0, 2);
        }

        //if (building != null) {
        //    building.transform.Translate(0, 0, GameControl.Instance.scrollSpeed * Time.deltaTime);
        //}

    }
}
