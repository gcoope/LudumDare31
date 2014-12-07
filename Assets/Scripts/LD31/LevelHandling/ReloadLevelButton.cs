using UnityEngine;
using System.Collections;

public class ReloadLevelButton : MonoBehaviour {

	public void ReloadLevel(){
		gameObject.DispatchGlobalEvent(GameEvents.ReloadLevel);
	}
}
