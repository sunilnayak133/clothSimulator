using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statechangerMidpoint : MonoBehaviour {

	//distance
	[SerializeField]
	private float x;

	//delta x
	private float delx;
	//velocity at the middle of the euler step
	private float vmid;

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
			//Euler Step
			delx = v * h;
			//Velocity at midpoint
			vmid = v + (h / 2 * (-k * (x + delx)/2)/ m);

			//???? 
			//v = vmid;

			//distance set using vmid
			x += h * vmid;
			//find velocity at current place
			v += h * (-k * x / m);
			//reset time
			time = 0;
		}

		//setting clamps on x
		if (x < 0.001 && x > -0.001)
			x = 0;

		//display
		GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y, x);

	}
}
