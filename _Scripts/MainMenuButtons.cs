using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour {

	// Use this for initialization
	void Start () {
			GameObject.Find("HelpMenu").transform.localScale = new Vector3(0, 0, 0); // Hide Help Screen
			Cursor.lockState = CursorLockMode.None; //Sow Mouse
        	Cursor.visible = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void PlayGame() {
		//Load intro level
				SceneManager.LoadScene(1, LoadSceneMode.Single); // 2 Is the introl level
		
	}
	public void QuitGame() {
		Application.Quit();
	}
	public void HelpMe() {
				//Hide and Show relevent info
				GameObject.Find("MainMenu").transform.localScale = new Vector3(0, 0, 0);
				GameObject.Find("HelpMenu").transform.localScale = new Vector3(1, 1, 1);
	}
	public void BackToMainMenu() {
				//Hide and Show relevent info
				GameObject.Find("HelpMenu").transform.localScale = new Vector3(0, 0, 0);
				GameObject.Find("MainMenu").transform.localScale = new Vector3(1, 1, 1);
	}
}
	