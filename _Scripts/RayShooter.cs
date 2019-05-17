using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour {
    protected Camera _camera;
    public float defaultDistance = 2f;
    // Use this for initialization
    void Start () {
        _camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked; // Hide mouse
        Cursor.visible = false;
	}
    void OnGUI(){ //small Crosshair in center screen
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "¦");
    }
    void Update () {
        if (Input.GetMouseButtonDown(0)) { //mouseclick
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
            	GameObject hitObject = hit.transform.gameObject;
            	ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
            	if (target != null) {
            		Debug.Log("Hit " + hit.point);
            		if (target.tag == "PlayerMadeBlock" || target.tag == "ai") {
                        Debug.Log(target.tag);
            			target.ReactToHit();
            		}else {
            			StartCoroutine(CubeIndicator(hit.point)); //If we didn't hit a ai or playermade block(ex a wall), make a block
            		}
            	}else {
            		StartCoroutine(CubeIndicator(hit.point)); // If target is deleted before this line is excectued
            	}
        	}
        	else {
	    		Debug.Log("Miss " + hit.point);
	        	StartCoroutine(CubeIndicatorPlacer());  // If we are free falling and want to make a block
            } 
	}
}
    private IEnumerator CubeIndicator(Vector3 pos) { //Make a platform onto an object
       
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.tag="PlayerMadeBlock";
        cube.AddComponent<ReactiveTarget>();
        Vector3 size = new Vector3(4, 0.1f, 4);
        cube.transform.localScale = size;
        cube.transform.position = pos;
        yield return new WaitForSeconds(10);
        Destroy(cube);

    }
     private IEnumerator CubeIndicatorPlacer() { //makes a platform in free space
       
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.tag="PlayerMadeBlock";
        cube.AddComponent<ReactiveTarget>();
        Vector3 size = new Vector3(4, 0.1f, 4);
        cube.transform.localScale = size;
      	cube.transform.position = _camera.transform.position + _camera.transform.forward * defaultDistance;
      	Debug.Log("Cube Created AT " + cube.transform.position);
      	yield return new WaitForSeconds(10);
        Destroy(cube);

    }
}