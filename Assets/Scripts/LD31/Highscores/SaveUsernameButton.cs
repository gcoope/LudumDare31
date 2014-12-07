using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class SaveUsernameButton : MonoBehaviour {

	private InputField inputField;
	private Text inputFieldText;
	public GameObject inputFieldObject;
	public GameObject inputFieldTextObject;
	public GameObject EventSystemManager;
	public GameObject EnterUsernameText;
	public GameObject gameNameText;
	public GameObject arrowImage;

	private Image buttonImage;
	public GameObject buttonTextObj;
	private bool EnterPressed = false;

	public void Start(){

		buttonImage = GetComponent<Image>();
		inputField = inputFieldObject.GetComponent<InputField>();
		inputFieldText = inputFieldObject.GetComponent<Text>();

		DOTween.Init();
	}

	public void Submit() {
		Debug.Log("Submit pressed?");
		if(inputField != null){
			if(inputField.text != "" && inputField.textComponent.text.Length > 0 && !inputField.text.Contains("\n")){
				HighscoreModel.Username = inputField.text;
				gameObject.DispatchGlobalEvent(GameEvents.StartGame);
				EnterUsernameText.SetActive(false);
				inputField.gameObject.transform.DOLocalMoveX(-430f, 0.5f, false);
				buttonTextObj.transform.DOLocalMoveX(430f, 0.5f, false);
				arrowImage.transform.DOLocalMoveY(-350f, 0.5f, false);
				transform.DOLocalMoveX(430f, 0.5f, false).OnComplete(OnTweenEnd);
				gameNameText.transform.DOLocalMoveY(12f, 0.5f, false);
			} else {
				inputField.text = "";
				inputField.textComponent.text = "";
				EnterPressed = false;
			}
		}
	}

	void OnTweenEnd(){
		transform.parent.gameObject.SetActive(false);
	}

	void Update() {
		if(Input.GetKeyUp(KeyCode.Return)){
			if(!EnterPressed){ 
				EnterPressed = true;
				Submit();
			}
		}
	}

	public void MouseHover(){
		if(buttonImage !=null) buttonImage.color = Color.gray;
		else Debug.Log("buttonImage is null?");
	}

	public void MouseExit(){
		if(buttonImage != null) buttonImage.color = Color.black;
	}
	
}