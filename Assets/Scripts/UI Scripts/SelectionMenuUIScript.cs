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
        SceneManagerScript.instance.titleScreenTransition();
    }

    public void tempEasyButtonSelected() {
        SceneManagerScript.instance.mainGameTransition();
    }
}
