using System;
using UnityEngine;

public class HighscoreModel : MonoBehaviour{
	
	public static string Username = "";
	public static int Score = 0;
	public static float Level1Score = 0;

	void Start() {
		DontDestroyOnLoad(this);
	}

}