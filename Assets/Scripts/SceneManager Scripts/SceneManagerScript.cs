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
    private TransitionLayerScript transitionLayer;

    void Awake() {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        transitionLayer = GameObject.FindGameObjectWithTag(Tags.TRANSITION_LAYER_TAG).GetComponent<TransitionLayerScript>();
    }

    private void Start() {
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void loadSelectionScreen() {
        SceneManager.LoadScene(Tags.SCENE_SELECTIONSCREEN);
    }
}
