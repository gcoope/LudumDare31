using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

	public float duration = 10f;
	public float timer = 0;
	private bool ticking = false;

	public GameObject timerTextObj;
	private Text timerText;

	void Awake(){
		gameObject.AddGlobalEventListener(GameEvents.StartGame, StartTimer);
		gameObject.AddGlobalEventListener(GameEvents.PauseGame, PauseTimer);
		gameObject.AddGlobalEventListener(GameEvents.GameOver, GameOver);
		gameObject.AddGlobalEventListener(GameEvents.ReloadLevel, ResetTime);
		gameObject.AddGlobalEventListener(GameEvents.NextLevel, ResetTime);
	}

	void OnDestroy(){
		gameObject.RemoveGlobalEventListener(GameEvents.StartGame, StartTimer);		
		gameObject.RemoveGlobalEventListener(GameEvents.PauseGame, PauseTimer);
		gameObject.RemoveGlobalEventListener(GameEvents.GameOver, GameOver);
		gameObject.RemoveGlobalEventListener(GameEvents.ReloadLevel, ResetTime);
		gameObject.RemoveGlobalEventListener(GameEvents.NextLevel, ResetTime);
	}

	void Start(){
		timerText = timerTextObj.GetComponent<Text>();
	}

	void StartTimer(EventObject evt){
		timer = duration;
		ticking = true;
	}

	void PauseTimer(EventObject evt){
		ticking = false;
	}

	void GameOver(EventObject evt){
		ticking = false;
		HighscoreModel.SetHighscore(timer);		
	}

	void ResetTime(EventObject evt){
		HighscoreModel.SetHighscore(0);
		timer = duration;
		ticking = true;
	}

	public float GetTimerValue() {
		return timer;
	}

	void Update(){
		if(ticking){
			timer -= Time.deltaTime;
			if(timer <= 0) {
				ticking = false;
				timerText.text = "0.00";
				HighscoreModel.SetHighscore(timer);
				gameObject.DispatchGlobalEvent(GameEvents.GameOver);
			}
		}
	}

	void FixedUpdate(){
		if(ticking) timerText.text = timer % 1 == 0 ? timer.ToString("0") : timer.ToString("0.00");
	}
}
