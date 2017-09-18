using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicBeat{

    protected static Conductor conductor = null;
    protected static SceneBehaviorScript sceneBehavior = null;

    public float timeIndex;         // The time at which a beat should be analyzed

    public static void setStaticVariables(Conductor conductor) {
        BasicBeat.conductor = conductor;
        sceneBehavior = GameObject.FindGameObjectWithTag(Tags.SCENE_BEHAVIOR_TAG).GetComponent<SceneBehaviorScript>();
    }

    public abstract void performBeat();
    public abstract void printBeatInfo();
}
