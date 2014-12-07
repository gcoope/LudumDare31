using UnityEngine;
using System.Collections;

public class NextLevelButton : MonoBehaviour {

	public void NextLevel(){
		gameObject.DispatchGlobalEvent(GameEvents.NextLevel);
	}
}
