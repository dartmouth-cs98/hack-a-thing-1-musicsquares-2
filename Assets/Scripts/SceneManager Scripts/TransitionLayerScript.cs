using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionLayerScript : MonoBehaviour {

    public static TransitionLayerScript instance = null;

    private bool isGoingToTitle, isGoingToSelection, isGoingToMainGame;

    [SerializeField]
    private Animator transitionAnim;

    void Awake() {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        
    }

    public void titleAnimEnd() {
        GameObject.FindGameObjectWithTag(Tags.TITLE_UI_MANAGER_TAG).GetComponent<TitleMenuUIScript>().titleFlashAnimEnd();
    }

    public void startTitleAnim() {
        transitionAnim.Play("StartingAppFlashAnim");
    }

    public void clearToWhiteAnim(int isGoingToScene) {
        switch (isGoingToScene) {
            case 0:
                isGoingToSelection = true;
                break;
            default:
                return;
        }
        transitionAnim.Play("ClearToWhiteAnim");
    }

    public void clearToBlackAnim(int isGoingToScene) {
        switch (isGoingToScene) {
            case 0:
                isGoingToTitle = true;
                break;
            case 1:
                isGoingToMainGame = true;
                break;
            default:
                return;
        }
        transitionAnim.Play("ClearToBlackAnim");
    }

    public void whiteToClearAnim() {
        transitionAnim.Play("WhiteToClearAnim");
    }

    public void blackToClearAnim() {
        transitionAnim.Play("BlackToClearAnim");
    }

    public void clearToWhiteAnimFinish() {
        SceneManagerScript.instance.loadSelectionScreen();
    }

    public void clearToBlackAnimFinish() {
        if (isGoingToTitle) {
            isGoingToTitle = false;
            SceneManagerScript.instance.loadTitleScreen();
        }
        else if (isGoingToMainGame) {
            isGoingToMainGame = false;
            SceneManagerScript.instance.loadMainGame();
        }
    }

    public void whiteToClearAnimFinish() {
        if (isGoingToSelection) {
            isGoingToSelection = false;
            GameObject.FindGameObjectWithTag(Tags.SELECTION_MENU_UI_MANAGER_TAG).GetComponent<SelectionMenuUIScript>().transitionLayerFinished();
        }
    }

    public void blackToClearAnimFinish() {

    }

}
