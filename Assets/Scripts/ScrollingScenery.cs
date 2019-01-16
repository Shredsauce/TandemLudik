using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingScenery : MonoBehaviour {

    [SerializeField] private GameObject buildingPrefab;

    [SerializeField] private Vector3 position;
    [SerializeField] private Vector3 rotation;
    [SerializeField] private float scale = 0.1f;


    void Update () {
        if (Input.GetKeyDown(KeyCode.L)) {
            Debug.Log("Load building");

            GameObject building = Instantiate(buildingPrefab);
            GameObject container = new GameObject("Building");
            // Make sure object is destroyed after it's out of view
            container.AddComponent<Obstacle>();

            building.transform.rotation = Quaternion.Euler(rotation);
            building.transform.SetParent(container.transform);

            container.transform.position = position;
            container.transform.localScale = new Vector3(scale, scale, scale);
        }

    }
}
