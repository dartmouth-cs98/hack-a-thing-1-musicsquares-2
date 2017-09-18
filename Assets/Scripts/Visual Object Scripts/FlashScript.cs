using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashScript : MonoBehaviour {

    private SpriteRenderer sprite;

    // TODO: Add the length for the flash to recover (like 1 second flashes or 10 second flashes)
    private bool flashAnimOn;
    private Color spriteColor;
    private float currentAlpha;
    private float currentFlashLerp;
    private static float[] startingAlphas = { 0.3f, 0.6f, 1.0f };
    private static float endingFlashThreshold = 0.01f;    // Alpha threshold at which the flash animation turns off
    private static float[] flashLerps = { 0.25f, 0.18f, 0.13f };

    private static int[] flashStrength = { 0, 1, 2 };

    void Awake() {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Start () {
        currentAlpha = sprite.color.a;
        spriteColor = sprite.color;
	}
	
	// Update is called once per frame
	void Update () {
        if (flashAnimOn)
            updateFlashAnim();
	}

    void updateAlpha() {
        spriteColor = sprite.color;
        spriteColor.a = currentAlpha;
        sprite.color = spriteColor;
    }

    void updateFlashAnim() {
        currentAlpha = Mathf.Lerp(currentAlpha, 0f, currentFlashLerp);
        if(currentAlpha < endingFlashThreshold) {
            currentAlpha = 0;
            flashAnimOn = false;
        }

        updateAlpha();
    }

    public void triggerFlash(int strength) {
        flashAnimOn = true;
        if (strength == flashStrength[0]) {
            currentAlpha = startingAlphas[0];
            currentFlashLerp = flashLerps[0];
        }
        else if (strength == flashStrength[1]) {
            currentAlpha = startingAlphas[1];
            currentFlashLerp = flashLerps[1];
        }
        else if (strength == flashStrength[2]) {
            currentAlpha = startingAlphas[2];
            currentFlashLerp = flashLerps[2];
        }
        else
            flashAnimOn = false;

        updateAlpha();
    }
}
