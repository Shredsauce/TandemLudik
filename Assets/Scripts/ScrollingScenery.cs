using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingScenery : MonoBehaviour {

    [SerializeField] private Building buildingPrefab;

    [SerializeField] private Vector3 position;
    [SerializeField] private Vector3 rotation;
    [SerializeField] private float scale = 0.1f;

    void Start () {
        StartCoroutine(PlaceNextBuilding(null));
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.L)) {

        }

    }

    private IEnumerator PlaceNextBuilding (Building prevBuilding) {

        // TODO: Hardcoded for testing
        float secondsToWait = 0.23f;

        // TODO: Figure out how many seconds to wait based on
        // 1. The length of the previous building prevBuilding
        // 2. How fast the world is scrolling past GameControl.Instance.scrollSpeed
        yield return new WaitForSeconds(secondsToWait);

        Debug.Log("Load building");
        Building building = Instantiate(buildingPrefab);
        GameObject container = new GameObject("Building");
        // Make sure object is destroyed after it's out of view
        container.AddComponent<Obstacle>();

        building.transform.rotation = Quaternion.Euler(rotation);
        building.transform.SetParent(container.transform);

        container.transform.position = position;

        Debug.Log(container.transform.position);
        container.transform.localScale = new Vector3(scale, scale, scale);

        StartCoroutine(PlaceNextBuilding(building));
    }
}
