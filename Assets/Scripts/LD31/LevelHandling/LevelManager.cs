using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

	public GameObject[] Levels;
	public int lvlIndex = 0;

	public void NextLevel(EventObject evt){
		if(lvlIndex + 1 < Levels.Length) {
			Destroy(Levels[lvlIndex]);
			Levels[lvlIndex + 1] = Instantiate(Resources.Load("Prefabs/Levels/Level" + (lvlIndex + 1).ToString())) as GameObject;
			lvlIndex++;
			HighscoreModel.CurrentLevelIndex = lvlIndex;			
		} else {
			Debug.Log("No more levels!"); // TODO Handle me
			Destroy(Levels[lvlIndex]);
			lvlIndex = 0;
			Levels[lvlIndex] = Instantiate(Resources.Load("Prefabs/Levels/Level" + (lvlIndex + 1).ToString())) as GameObject;
			HighscoreModel.CurrentLevelIndex = lvlIndex;			
		}
	}

	public void ReloadGame(EventObject evt){
		Application.LoadLevel(Application.loadedLevel);
	}

	public void StartGame(EventObject evt){
		HighscoreModel.CurrentLevelIndex = lvlIndex;
		lvlIndex = 0;
		Levels[lvlIndex].SetActive(true);
	}

	public void ReloadLevel(EventObject evt){
		Destroy(Levels[lvlIndex]);
		Levels[lvlIndex] = Instantiate(Resources.Load("Prefabs/Levels/Level" + (lvlIndex + 1).ToString())) as GameObject;
		HighscoreModel.CurrentLevelIndex = lvlIndex;
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
