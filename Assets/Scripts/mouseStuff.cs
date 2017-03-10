using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseStuff : MonoBehaviour {

	[SerializeField]
	private float mRadius;

	private float d = 0;
	[SerializeField]
	private Vector3 mousePos;
	[SerializeField]
	private Vector3 objPos;

	private Vector3 pressedAt;
	private Vector3 releaseAt;

	[SerializeField]
	private float forceMult;

	private PointMass pm;

	void Start () {

		pm = GetComponent<PointMass> ();
		mousePos = Input.mousePosition;
		objPos = Camera.main.WorldToScreenPoint(transform.position);
	}

	void Update () {
		
		mousePos = Input.mousePosition;
		objPos = Camera.main.WorldToScreenPoint(transform.position);
		CalcDistMouse ();

		if (Input.GetMouseButtonDown(0))
			pressedAt = mousePos;

		if (Input.GetMouseButtonUp(0)) 
		{
			releaseAt = mousePos;
			if (CalcDistMouse ()) 
			{
				Vector3 force = pressedAt - releaseAt;
				force.y = -force.y;
				pm.AddForce (force * forceMult);
			}
		}
		
	}
		

	bool CalcDistMouse()
	{
		d = (pressedAt - objPos).magnitude;

		if (d < mRadius)
			return true;
		else
			return false;
	}

}
