using System;
using UnityEngine;

public class SubmitScoreButton : MonoBehaviour {

	public void Submit() {
		gameObject.DispatchGlobalEvent(ScoreEvents.SubmitScoreEvent);
	}

}