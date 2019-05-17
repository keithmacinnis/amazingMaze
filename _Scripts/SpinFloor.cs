using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinFloor : MonoBehaviour {
	public float speed = 1.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Spins an object
		transform.Rotate(Time.deltaTime*speed, 0, 0);
	}
}
