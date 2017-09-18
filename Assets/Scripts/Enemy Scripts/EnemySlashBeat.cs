using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlashBeat : BasicBeat {
    public override void performBeat() {
        throw new NotImplementedException();
    }

    public override void printBeatInfo() {
        throw new NotImplementedException();
    }

    /*
        private float descendTime;      // How much time it takes to descend onto the grid
        private float detonationTime;   // The time it takes for bomb to detonate after landing
        private int bombType;           // Type of Bomb
        private int spawnType;          // How to spawn bomb on grid; See Tags for more values
        private int xLoc = 0, yLoc = 0;

        public BombBeat(float startBeat, float syncopateScale, float descendTime, float beatsUntilDetonation, int bombType, int spawnType, int xLoc, int yLoc) {
            timeIndex = ((startBeat + syncopateScale) * parent.milliThreshold) - descendTime;
            this.descendTime = descendTime * parent.milliThreshold;
            detonationTime = beatsUntilDetonation * parent.milliThreshold;
            this.bombType = bombType;

            this.spawnType = spawnType;
            this.xLoc = xLoc;
            this.yLoc = yLoc;
        }

        public override void performBeat() {
            gamePlayManager.spawnBomb(descendTime, detonationTime, bombType, spawnType, xLoc, yLoc);
        }

        public override void printBeatInfo() {
            Debug.Log("Bomb Beat\nTime Index: " + timeIndex + "\nBomb Type: " + bombType);
     */
}
