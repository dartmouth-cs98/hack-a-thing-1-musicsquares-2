using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBeat : BasicBeat {

    public int enemyType = 0;

    // Other things will come later
	public EnemyBeat(float time, int enemyType) {
        timeIndex = time;
        this.enemyType = enemyType;
    }

    public override void performBeat() {
        sceneBehavior.spawnEnemyBeat(this);
    }

    public override void printBeatInfo() {
        Debug.Log("Time Index: " + timeIndex);
    }
}
