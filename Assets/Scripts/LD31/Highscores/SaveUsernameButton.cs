using System;
using UnityEngine;
using UnityEngine.UI;

public class SaveUsernameButton : MonoBehaviour {

	public InputField inputField;
	public Text errorText;

	public void Start(){
		if(errorText != null) {
			errorText.text = "";
		}
	}

	public void Submit() {
		if(inputField != null){
			if(inputField.text != ""){
				HighscoreModel.Username = inputField.text;
				Debug.Log("[SaveUsernameButton] Set username to: " + inputField.text + ", loading next level!");
				Application.LoadLevel(Application.loadedLevel + 1);
			} else {
				errorText.text = "Please enter a name!";
			}
		}
	}
	
}