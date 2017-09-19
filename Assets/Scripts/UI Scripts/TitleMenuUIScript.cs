using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class TitleMenuUIScript : MonoBehaviour {

    [SerializeField]
    private TextMeshProUGUI subtitleText;

    [SerializeField]
    private GameObject quitNotif;

    [SerializeField]
    private TransitionLayerScript transitionLayer;

    private bool startingAnimFinished;
    private float subtitleFlashingTime = 0f;
    private Color32 subtitleColor;

    // Use this for initialization
    void Start () {
        subtitleColor = subtitleText.faceColor;
        subtitleColor.a = 0x00;
        subtitleText.faceColor = subtitleColor;
	}
	
	// Update is called once per frame
	void Update () {
        HandleTouchEvent();

        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (quitNotif.activeInHierarchy)
                confirmQuitApplication();
            else
                quitNotifAppear();
        }

        if (startingAnimFinished) {
            subtitleFlashingTime += Time.deltaTime;
            subtitleColor.a = (byte)Mathf.RoundToInt((-0.5f * Mathf.Cos(subtitleFlashingTime * 2 * Mathf.PI) + 0.5f) * 255f);
            subtitleText.faceColor = subtitleColor;
        }
	}

    void HandleTouchEvent() {
        if (!quitNotif.activeInHierarchy && Input.GetMouseButtonDown(0)) {
            if (!startingAnimFinished) {
                // TODO: Later, make this skip title Transition
            }
            else {
                GameObject.FindGameObjectWithTag(Tags.SCENE_MANAGER_TAG).GetComponent<SceneManagerScript>().selectionScreenTransition();
            }
        }
    }

    public void titleFlashAnimEnd() {
        startingAnimFinished = true;
    }

    void quitNotifAppear() {
        quitNotif.SetActive(true);
    }

    public void quitNotifDisappear() {
        quitNotif.SetActive(false);
    }

    public void confirmQuitApplication() {
        Application.Quit();
    }

}
