using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour {

    /* TODO:
     * Make this single instance
     * Make ref to transition state
     * Make animation work
     */
    public static SceneManagerScript instance = null;

    void Awake() {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

    }

    public void titleScreenTransition() {
        TransitionLayerScript.instance.clearToBlackAnim(0);
    }

    public void selectionScreenTransition() {
        TransitionLayerScript.instance.clearToWhiteAnim(0);
    }

    public void mainGameTransition() {
        TransitionLayerScript.instance.clearToBlackAnim(1);
    }

    public void loadTitleScreen() {
        SceneManager.LoadScene(Tags.SCENE_TITLESCREEN);
        TransitionLayerScript.instance.startTitleAnim();
    }

    public void loadSelectionScreen() {
        SceneManager.LoadScene(Tags.SCENE_SELECTIONSCREEN);
        TransitionLayerScript.instance.whiteToClearAnim();
    }

    public void loadMainGame() {

    }
}
