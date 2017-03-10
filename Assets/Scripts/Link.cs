using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Link : MonoBehaviour {

	public float restD;
	public float stiffness;
	public float tearSens;
	public GameObject p1;
	public GameObject p2;

	public bool drawMe = true;
	private Vector3 diff;
	private float d;

	public void Solve()
	{
		diff =  p1.transform.position - p2.transform.position;
		d = diff.magnitude;

		float difference = (restD - d) / d;

		if (d > tearSens) 
			p1.GetComponent<PointMass> ().removeLink (this);

		// Inverse the mass quantities and multiply by stiffness = (k/m) term
		float im1 = 1 / p1.GetComponent<PointMass>().mass;
		float im2 = 1 / p2.GetComponent<PointMass>().mass;
		float scalarP1 = (im1 / (im1 + im2)) * stiffness;
		float scalarP2 = stiffness - scalarP1;

		// Push/pull based on mass
		// x' = x + k(diff_relative)/m
		p1.transform.position = p1.transform.position + diff * scalarP1 * difference;
		p2.transform.position = p2.transform.position - diff * scalarP2 * difference;

	}


	void Start () {
		stiffness = 0.5f;
		tearSens = 30;
	}


	void Update () 
	{
		if (drawMe) 
		{
			Debug.DrawLine (p1.transform.position, p2.transform.position, Color.blue, Time.deltaTime);
		}
	}
}
