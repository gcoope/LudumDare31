using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

	public float duration = 10f;
	private float timer = 0;
	private bool ticking = false;

	public GameObject timerTextObj;
	private Text timerText;

	void Awake(){
		gameObject.AddGlobalEventListener(GameEvents.StartGame, StartTimer);
	}

	void Start(){
		timerText = timerTextObj.GetComponent<Text>();
	}

	void StartTimer(EventObject evt){
		timer = duration;
		ticking = true;
	}

	void Update(){
		if(ticking){
			timer -= Time.deltaTime;
			if(timer <= 0) {
				ticking = false;
			}
		}
	}

	void FixedUpdate(){
		if(ticking) timerText.text = timer.ToString();
	}
}
