using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionLayerScript : MonoBehaviour {

    public static TransitionLayerScript instance = null;

    [SerializeField]
    private Animator transitionAnim;

    void Awake() {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        
    }

    public void skipTitleAnim() {
        transitionAnim.StopPlayback();
        GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 0);
    }

    public void titleAnimEnd() {
        GameObject.FindGameObjectWithTag(Tags.TITLE_UI_MANAGER_TAG).GetComponent<TitleMenuUIScript>().titleFlashAnimEnd();
    }

    public void startTitleAnim() {

    }

    public void clearToWhiteAnim() {

    }

    public void whiteToClearAnim() {

    }

    public void clearToBlackAnim() {

    }

    public void blackToClearAnim() {

    }

    void Update () {
		
	}
}
