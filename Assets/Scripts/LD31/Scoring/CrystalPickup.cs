using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CrystalPickup : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D col) {
		if(col.gameObject.tag == "Player"){
			gameObject.DispatchGlobalEvent(ScoreEvents.PickedUpCollectable);
			Destroy(gameObject);
		}

	}
	
}
