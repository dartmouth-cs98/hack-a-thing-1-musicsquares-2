using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualBehaviorScript : MonoBehaviour {

    private Transform backgroundFlash, foregroundFlash;

    void Awake() {
        backgroundFlash = GameObject.Find(Tags.BACKGROUNDFLASH_NAME).transform;
        foregroundFlash = GameObject.Find(Tags.FOREGROUNDFLASH_NAME).transform;
    }

    void Update() {
        
    }

    public void triggerBackgroundFlash(int strength) {
        backgroundFlash.GetComponent<FlashScript>().triggerFlash(strength);
    }

    public void triggerForegroundFlash(int strength) {
        foregroundFlash.GetComponent<FlashScript>().triggerFlash(strength);
    }

}
