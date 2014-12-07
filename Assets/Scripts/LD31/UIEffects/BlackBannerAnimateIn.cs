using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class BlackBannerAnimateIn : MonoBehaviour {

	public float endWidth = 63f;
	public float endHeight = 5f;

	public GameObject timerObject;
	public GameObject counterObject;

	void Awake() {
		gameObject.AddGlobalEventListener(GameEvents.StartGame, BeginAnimation);
		gameObject.AddGlobalEventListener(GameEvents.NextLevel, BeginAnimation);
		gameObject.AddGlobalEventListener(GameEvents.ReloadLevel, BeginAnimation);
		gameObject.AddGlobalEventListener(GameEvents.GameOver, HideMe);
		GetComponent<Image>().enabled = false;
	}

	void OnDestroy() {
		gameObject.RemoveGlobalEventListener(GameEvents.StartGame, BeginAnimation);		
		gameObject.RemoveGlobalEventListener(GameEvents.NextLevel, BeginAnimation);
		gameObject.RemoveGlobalEventListener(GameEvents.ReloadLevel, BeginAnimation);
		gameObject.RemoveGlobalEventListener(GameEvents.GameOver, HideMe);
	}

	void Start(){
		timerObject.SetActive(false);
		counterObject.SetActive(false);
	}

	void BeginAnimation(EventObject evt) {
		GetComponent<Image>().enabled = true;
		transform.DOScaleX(endWidth, 0.5f).SetEase(Ease.Linear).OnComplete(OnEndHeightAnim);
	}

	void OnEndHeightAnim(){
		transform.DOScaleY(endHeight, 0.3f).SetEase(Ease.Linear).OnComplete(BannerAnimatedIn);
	}
	

	void BannerAnimatedIn(){
		timerObject.SetActive(true);
		counterObject.SetActive(true);
	}

	void HideMe(EventObject evt){
		transform.DOScaleY(0, 0.25f).SetEase(Ease.Linear).SetDelay(0.5f);
		timerObject.SetActive(false);
		counterObject.SetActive(false);
	}

}
