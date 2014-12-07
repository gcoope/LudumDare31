using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

	public GameObject[] Levels;
	public int lvlIndex = 0;

	void Start(){
	}
	
	public void NextLevel(EventObject evt){
		if(Levels != null) {
			if(lvlIndex + 1 < Levels.Length) {
				Levels[lvlIndex].SetActive(false);
				Levels[lvlIndex + 1].SetActive(true);
				lvlIndex++;
			} else {
				Levels[lvlIndex].SetActive(false);
				lvlIndex = 0;
				Levels[0].SetActive(true);
			}
		}
	}

	public void ReloadGame(EventObject evt){
		Application.LoadLevel(Application.loadedLevel);
	}

	public void StartGame(EventObject evt){
		lvlIndex = 0;
		Levels[lvlIndex].SetActive(true);
	}

	public void ReloadLevel(EventObject evt){
		//
	}


	void Awake(){
		gameObject.AddGlobalEventListener(GameEvents.NextLevel, NextLevel);
		gameObject.AddGlobalEventListener(GameEvents.ReloadGame, ReloadGame);
		gameObject.AddGlobalEventListener(GameEvents.StartGame, StartGame);
		gameObject.AddGlobalEventListener(GameEvents.ReloadLevel, ReloadLevel);
	}
	
	void OnDestroy() {
		gameObject.RemoveGlobalEventListener(GameEvents.NextLevel, NextLevel);
		gameObject.RemoveGlobalEventListener(GameEvents.ReloadGame, ReloadGame);
		gameObject.RemoveGlobalEventListener(GameEvents.StartGame, StartGame);
		gameObject.RemoveGlobalEventListener(GameEvents.ReloadLevel, ReloadLevel);
	}
}
