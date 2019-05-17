using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour {

	public void ReactToHit() {
		StartCoroutine(Die());
	}
	private IEnumerator Die() { //Makes the target turn to its side upon pendending destruction
		this.transform.Rotate(-80f,0f,-80f);
		Ai kill = GetComponent<Ai>();
		if (kill != null) {
			kill.kill(); //Ensures the object no longer moves around like in terms of an ai walking 
		}
		yield return new WaitForSeconds(0.3f);
		Destroy(this.gameObject);
	}
}
