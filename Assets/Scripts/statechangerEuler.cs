using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statechangerEuler : MonoBehaviour {
	//distance
	[SerializeField]
	private float x;

	//spring constant
	[SerializeField]
	private float k;

	//velocity
	[SerializeField]
	private float v;

	//mass
	[SerializeField]
	private float m;

	//Time step
	[SerializeField]
	private float h;

	//time
	[SerializeField]
	private float time = 0;




	// Use this for initialization
	void Start () {
		v = 0;
	}

	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		//if timestep has been reached
		if (time >= h) 
		{
			//calculate velocity
			v += h * ( -k * x / m);
			//calculate distance
			x += h * v;
			//reset time
			time = 0;
		}

		//clamp x
		if (x < 0.01 && x > -0.01)
			x = 0;
			
		//display
		GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y, x);

	}
}
