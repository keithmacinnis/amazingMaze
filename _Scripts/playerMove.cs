using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMove : MonoBehaviour {
    public float speed = 10.0f;
    public float gravity = 10.0f;
    public float jumpSensititivty = 3.0f;
    public float freefallThreshold =-76;

    protected CharacterController _charController;
    private Vector3 moveDirection = Vector3.zero;

    void Start () {
        _charController = GetComponent<CharacterController>();
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)){ //Exit to menu
            SceneManager.LoadScene("MainMenuFirst", LoadSceneMode.Single);
        }

        if (_charController.isGrounded) {  //We move only on the ground
            float x = (float)(Input.GetAxis("Horizontal"));
            float z = (float)(Input.GetAxis("Vertical"));
            moveDirection = new Vector3(x, 0.0f, z);
            moveDirection *= speed;
            moveDirection = transform.TransformDirection(moveDirection);//Creates Movement realtive to camera rather than gameworld. 
            if (Input.GetKeyDown(KeyCode.Space)){
                moveDirection.y = jumpSensititivty; //Jump
            }   
        } else {
            //Check for free falling if not grounded, and if so exit game
            if (transform.position.y < freefallThreshold) {
                SceneManager.LoadScene("MainMenuFirst", LoadSceneMode.Single);
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;  //insensative to orientation therefore ommited from the above transformation. Also creates some bad effects if includede. Gravity gets time * twice
        _charController.Move(moveDirection * Time.deltaTime);
    }
}
