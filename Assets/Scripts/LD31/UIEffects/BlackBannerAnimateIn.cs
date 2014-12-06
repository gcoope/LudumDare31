using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class BlackBannerAnimateIn : MonoBehaviour {

	public float endWidth = 63f;
	public float endHeight = 5f;
	private float rectWidth;
	private float rectHeight;

	void Awake() {
		gameObject.AddGlobalEventListener(GameEvents.StartGame, BeginAnimation);
		GetComponent<Image>().enabled = false;
		rectWidth = GetComponent<RectTransform>().sizeDelta.x;
	}

	void OnDestroy() {
		gameObject.RemoveGlobalEventListener(GameEvents.StartGame, BeginAnimation);		
	}

	void BeginAnimation(EventObject evt) {
		GetComponent<Image>().enabled = true;
		transform.DOScaleX(endWidth, 0.5f).SetEase(Ease.Linear).OnComplete(OnEndHeightAnim);
	}

	void OnEndHeightAnim(){
		transform.DOScaleY(endHeight, 0.3f).SetEase(Ease.Linear);

	}
}
