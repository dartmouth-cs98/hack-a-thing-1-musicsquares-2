using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualBeat : BasicBeat {

    public int visualType = 0;

    // Other things will come later
    public VisualBeat(float time, int visualType) {
        timeIndex = time;
        this.visualType = visualType;
    }

    public override void performBeat() {
        sceneBehavior.performVisualBeat(this);
    }

    public override void printBeatInfo() {
        Debug.Log("Time Index: " + timeIndex);
    }
}
