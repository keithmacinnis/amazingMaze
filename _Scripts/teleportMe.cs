using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class teleportMe : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") { //only the player object should trigger level changes
			StartCoroutine(halfSecond());
		}
	}
	IEnumerator halfSecond() {
		yield return new WaitForSeconds(0.8f);
		if (SceneManager.GetActiveScene().buildIndex != 3) { //Play until the last level, then return to main menu
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
			}
		else {
			Debug.Log("MainMenuSent");
			SceneManager.LoadScene("MainMenuFirst", LoadSceneMode.Single);
		}
	}
}
