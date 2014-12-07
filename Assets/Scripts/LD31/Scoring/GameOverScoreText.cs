using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverScoreText : MonoBehaviour {

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
		Debug.Log(HighscoreModel.Level1Score);
		float score = HighscoreModel.Level1Score;
		GetComponent<Text>().text = score % 1 == 0 ? score.ToString("0") : score.ToString("0.00");
	}
}
