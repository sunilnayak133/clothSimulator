using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridmaker : MonoBehaviour {

	[SerializeField]
	private GameObject sph;
	private GameObject[] grid;

	[SerializeField]
	private int width;
	[SerializeField]
	private int height;

	void Start () {
		grid = new GameObject[width * height];


		for (int j = 0, count = 0; j < height; j++) {
			for (int i = 0; i < width; i++, count++) {
				grid [count] = Instantiate (sph, new Vector3 (i, j), Quaternion.identity,null);
			}
		}
	}
}
