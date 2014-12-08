using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CollectablesCounter : MonoBehaviour {

	public GameObject collectionsTextObject;
	public int totalCollectionAmount = 3;

	private int currentCollectionAmount;
	private Text collectionsText;

	void Awake(){
		gameObject.AddGlobalEventListener(ScoreEvents.PickedUpCollectable, AddToCounter);
		gameObject.AddGlobalEventListener(GameEvents.ReloadLevel, ResetCounter);
		gameObject.AddGlobalEventListener(GameEvents.NextLevel, ResetCounter);
	}

	void OnDestroy(){
		gameObject.RemoveGlobalEventListener(ScoreEvents.PickedUpCollectable, AddToCounter);
		gameObject.RemoveGlobalEventListener(GameEvents.ReloadLevel, ResetCounter);
		gameObject.RemoveGlobalEventListener(GameEvents.NextLevel, ResetCounter);
	}

	void Start () {
		if(collectionsTextObject != null) collectionsText = collectionsTextObject.GetComponent<Text>();
	}

	void UpdateCounter(){
		if(collectionsText != null) collectionsText.text = currentCollectionAmount + "/" + totalCollectionAmount;
	}

	void AddToCounter(EventObject evt){
		currentCollectionAmount++;
		UpdateCounter();
		if(currentCollectionAmount == totalCollectionAmount) {
			gameObject.DispatchGlobalEvent(GameEvents.GameOver);
		}
	}

	void ResetCounter(EventObject evt){
		currentCollectionAmount = 0;
		UpdateCounter();
	}

}
