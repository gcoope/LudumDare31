using System;
using UnityEngine;

public class HighscoreModel : MonoBehaviour{

	public static string Username = "";
	public static int Score = 0;
	public static float Level1Score = 0;
	public static int CurrentLevelIndex = 0;
	public static float CurrentLevelScore = 0;

	public static void SetHighscore(float newScore){
		string key = "highscore" + CurrentLevelIndex.ToString();
		CurrentLevelScore = 10f - newScore;
		if(PlayerPrefs.HasKey(key)){
			Debug.Log("We have this key! Current score is " + CurrentLevelScore + ", but player prefs has " +  PlayerPrefs.GetFloat(key));
			if(CurrentLevelScore < PlayerPrefs.GetFloat(key)){
				PlayerPrefs.SetFloat(key, CurrentLevelScore);
			}
		} else {
			PlayerPrefs.SetFloat(key, CurrentLevelScore);
		}
	}

	public static float GetHighscore(){
		Debug.Log("PlayerPrefsHighscore: " + PlayerPrefs.GetFloat("highscore" + CurrentLevelIndex.ToString()));
		if(PlayerPrefs.HasKey("highscore" + CurrentLevelIndex.ToString())){
			return PlayerPrefs.GetFloat("highscore" + CurrentLevelIndex.ToString());
		}
		else return 10f;
	}

	void Start() {
		DontDestroyOnLoad(this);
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.R)) PlayerPrefs.DeleteAll();
	}

}