using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statechangerVerlet : MonoBehaviour {

	[SerializeField]
	private GameObject connect;
	//distance
	[SerializeField]
	private float d;

	//old x
	[SerializeField]
	private float d0;



	//spring constant
	[SerializeField]
	private float k;

	//mass
	[SerializeField]
	private float m;

	//Time step
	[SerializeField]
	private float h;

	[SerializeField]
	private float deld;

	//time
	[SerializeField]
	private float time = 0;




	// Use this for initialization
	void Start () {
		d = transform.position.z - connect.transform.position.z;
		d0 = d;
	}

	// Update is called once per frame
	void Update () {

		transform.LookAt (connect.transform);

		time += Time.deltaTime;
		//if timestep has been reached
		if (time >= h) 
		{
			
			float dtemp = d0;
			d0 = d;
			d  = 2 * d - dtemp + (h * h * (-k * d) / m);

			//reset time
			time = 0;
		}

		//setting clamps on x
		if (d < 0.001 && d > -0.001)
			d = 0;
		float z = connect.transform.position.z;
		//display
		GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y, z + d);

	}
}
