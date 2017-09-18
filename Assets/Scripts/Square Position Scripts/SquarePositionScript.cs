using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquarePositionScript : MonoBehaviour {

    private bool pulseAnimOn;
    private float defaultScale;
    private float currentScale;
    private static float startingScale = 1.6f;
    private static float endingScaleThreshold = 0.01f;     // Additional scaling to defaultScale at which the pulse animation turns off
    private static float scaleLerp = 0.25f;

	// Use this for initialization
	void Start () {
        defaultScale = transform.localScale.x;
        currentScale = defaultScale;
	}
	
	// Update is called once per frame
	void Update () {
        if (pulseAnimOn)
            updatePulseAnim();
	}
    
    void updatePulseAnim() {
        currentScale = Mathf.Lerp(currentScale, defaultScale, scaleLerp);
        if(currentScale < defaultScale + endingScaleThreshold) {
            currentScale = defaultScale;
            pulseAnimOn = false;
        }
        transform.localScale = Vector3.one * currentScale;
    }

    public void triggerPulse() {
        pulseAnimOn = true;
        transform.localScale = Vector3.one * startingScale;
        currentScale = startingScale;
    }

    void updateJumpAnim() {

    }

    public void triggerJump() {

    }

}
