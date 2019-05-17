using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ai : MonoBehaviour {
	private bool _notDead; //WE don't want dead ai traverseing the level
	public float speed = 2.5f;
	public float avoidanceRange = 4.0f;
	public float turnAngleRange = 100.0f;
	public float gravity = 0.0f;
	// Use this for initialization
	void Start () {
		_notDead = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (_notDead){
			transform.Translate(0,(-gravity * Time.deltaTime),speed * Time.deltaTime);
			Ray ray = new Ray(transform.position, transform.forward);
			RaycastHit hit;
			if (Physics.SphereCast(ray, 0.75f, out hit)) {
				GameObject hitObject = hit.transform.gameObject;
				if (hit.distance < avoidanceRange) {
					float turnAngle = Random.Range((-1*turnAngleRange),turnAngleRange);
					transform.Rotate (-0,turnAngle,0);
					//If its a player that we ran into, we kill them
					if (hitObject.name == "Player") {
						//Go to game over screen
						SceneManager.LoadScene("MainMenuFirst", LoadSceneMode.Single);
					}
				}
			}
		}	
	}

	public void kill() {//public setter
		_notDead = false;
	}
}
