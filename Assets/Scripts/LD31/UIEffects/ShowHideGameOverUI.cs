using UnityEngine;
using System.Collections;

public class ShowHideGameOverUI : MonoBehaviour {

	public GameObject MenuContent;
	private Vector3 startPos;

	void Start () {
		startPos = MenuContent.transform.position;
		DisableChildren();
	}

	void Awake(){
		gameObject.AddGlobalEventListener(UIEvents.AnimatedIn, EnableChildren);
	}

	void OnDestroy(){
		gameObject.RemoveGlobalEventListener(UIEvents.AnimatedIn, EnableChildren);
	}

	void DisableChildren(EventObject evt){ DisableChildren(); }
	void DisableChildren(){
		MenuContent.transform.localPosition = new Vector3(2000,0,0);
	}

	void EnableChildren(EventObject evt){EnableChildren();}
	void EnableChildren(){
		MenuContent.transform.position = startPos;
	}

}
