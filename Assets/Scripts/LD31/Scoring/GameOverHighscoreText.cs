using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverHighscoreText : MonoBehaviour {
	
	private Text scoreText;
	
	void Awake(){
		gameObject.AddGlobalEventListener(GameEvents.ReloadLevel, HideText);
		gameObject.AddGlobalEventListener(UIEvents.AnimatedIn, ShowText);
	}
	
	void OnDestroy(){
		gameObject.RemoveGlobalEventListener(GameEvents.ReloadLevel, HideText);
		gameObject.RemoveGlobalEventListener(UIEvents.AnimatedIn, ShowText);
	}
	
	void HideText(EventObject evt){
		scoreText.text = "";
	}
	
	void Start(){
		if(scoreText == null) scoreText = GetComponent<Text>();
		scoreText.text = "";
	}
	
	void OnEnable(){
		if(scoreText == null) scoreText = GetComponent<Text>();		
	}

	
	void ShowText(EventObject evt){
		Debug.Log(HighscoreModel.CurrentLevelScore + ", " + HighscoreModel.GetHighscore());
		if(HighscoreModel.CurrentLevelScore <= HighscoreModel.GetHighscore()){
			GetComponent<Text>().text = "New highscore!";
		} else {
			GetComponent<Text>().text = "";
		}
	}
}
