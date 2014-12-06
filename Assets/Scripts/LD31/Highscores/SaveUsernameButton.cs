using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class SaveUsernameButton : MonoBehaviour {

	public InputField inputField;
	public Text errorText;
	public GameObject EventSystemManager;
	public GameObject EnterUsernameText;
	public GameObject gameNameText;

	private Image buttonImage;
	public GameObject buttonTextObj;
	private bool EnterPressed = false;

	public void Start(){
		if(errorText != null) {
			errorText.text = "";
		}

		buttonImage = GetComponent<Image>();

		DOTween.Init();
	}

	public void Submit() {
		if(inputField != null){
			if(inputField.text != "" && inputField.text.Length > 0 && !inputField.text.Contains("\n")){
				HighscoreModel.Username = inputField.text;
				Debug.Log("[SaveUsernameButton] Set username to: " + inputField.text + ", starting game!");
				gameObject.DispatchGlobalEvent(PlayerEvents.StartGame);
				EnterUsernameText.SetActive(false);
				inputField.gameObject.transform.DOLocalMoveX(-430f, 0.5f, false);
				buttonTextObj.transform.DOLocalMoveX(430f, 0.5f, false);
				transform.DOLocalMoveX(430f, 0.5f, false).OnComplete(OnTweenEnd);
				gameNameText.transform.DOLocalMoveY(6f, 0.5f, false);
			} else {
				errorText.text = "Please enter a name!";
				inputField.text = "";
				inputField.ActivateInputField();
				EnterPressed = false;
			}
		}
	}

	void OnTweenEnd(){
		transform.parent.gameObject.SetActive(false);
	}

	void Update() {
		if(Input.GetKeyDown(KeyCode.Return)){
			if(!EnterPressed){ 
				EnterPressed = true;
				Submit();
			}
		}
	}

	public void MouseHover(){
		if(buttonImage !=null) buttonImage.color = Color.gray;
	}

	public void MouseExit(){
		if(buttonImage != null) buttonImage.color = Color.black;
	}
	
}