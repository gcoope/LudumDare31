using System;
using UnityEngine;

public class HighscoreModel : MonoBehaviour{
	
	public static string Username = "";
	public static int Score = 0;

	void Start() {
		DontDestroyOnLoad(this);
		Username = "";
		Score = 0;
	}

}