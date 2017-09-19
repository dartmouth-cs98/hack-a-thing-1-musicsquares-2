using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionMenuUIScript : MonoBehaviour {

    private bool transitionAnimFinished;

    // Update is called once per frame
    void Update () {
        if (transitionAnimFinished) {
            if (Input.GetKeyDown(KeyCode.Escape))
                goToTitleScreen();
        }
    }

    public void transitionLayerFinished() {
        transitionAnimFinished = true;
    }

    public void goToTitleScreen() {
        GameObject.FindGameObjectWithTag(Tags.SCENE_MANAGER_TAG).GetComponent<SceneManagerScript>().titleScreenTransition();
    }
}
