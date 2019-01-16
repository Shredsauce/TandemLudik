using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePlex : MonoBehaviour {

    [SerializeField] private GameObject facadePrefab;
    [SerializeField] private GameObject windowPrefab;


    [SerializeField] private float width = 5f;
    [SerializeField] private float balconyWidth = 3f;
    [SerializeField] private float foundationHeight = 1f;
    [SerializeField] private float storyHeight = 2f;
    [SerializeField] private int stories = 3;

    void Start () {
		
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.G)) {
            Debug.Log("Generate plex");

            Create();
        }
	}

    public GameObject Create () {

        GameObject plex = new GameObject("Plex");

        GameObject facade = Instantiate(facadePrefab);

        facade.transform.localScale = new Vector3(
            width,
            (storyHeight * stories) + foundationHeight,
            facade.transform.localScale.z
        );
        facade.transform.parent = plex.transform;

        for (int i = 0; i < stories; i++) {
            GameObject window1 = Instantiate(windowPrefab);
            window1.transform.position = new Vector3(
                width / 2,
                0,
                0
            );
            window1.transform.parent = plex.transform;

            GameObject window2 = Instantiate(windowPrefab);
            window2.transform.position = new Vector3(
                0,
                0,
                0
            );
            window2.transform.parent = plex.transform;

            //GameObject window3 = Instantiate(windowPrefab);
            //window3.transform.position = new Vector3(
            //    1,
            //    0,
            //    0
            //);
            //window3.transform.parent = plex.transform;
        }

        return plex;
    }
}
