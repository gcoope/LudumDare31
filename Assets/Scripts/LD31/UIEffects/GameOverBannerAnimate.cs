using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class GameOverBannerAnimate : MonoBehaviour {
	
	public float endWidth = 63f;
	public float endHeight = 11f;
	public GameObject content;
	
	void Awake() {
		gameObject.AddGlobalEventListener(GameEvents.GameOver, BeginAnimation);
		gameObject.AddGlobalEventListener(GameEvents.ReloadLevel, HideMe);
		GetComponent<Image>().enabled = false;
	}
	
	void OnDestroy() {
		gameObject.RemoveGlobalEventListener(GameEvents.GameOver, BeginAnimation);		
		gameObject.RemoveGlobalEventListener(GameEvents.ReloadLevel, HideMe);		
	}
	
	void BeginAnimation(EventObject evt) {
		GetComponent<Image>().enabled = true;
		transform.DOScaleX(endWidth, 0.5f).SetEase(Ease.Linear).OnComplete(OnEndHeightAnim);
	}
	
	void OnEndHeightAnim(){
		transform.DOScaleY(endHeight, 0.5f).SetEase(Ease.Linear).OnComplete(FinishedAnimatingIn);		
	}

	void FinishedAnimatingIn(){
		content.SetActive(true);		
		gameObject.DispatchGlobalEvent(UIEvents.AnimatedIn);
	}

	void HideMe(EventObject evt){
		transform.DOScaleY(0, 0.5f).SetEase(Ease.Linear);	
		content.SetActive(false);
	}


}
