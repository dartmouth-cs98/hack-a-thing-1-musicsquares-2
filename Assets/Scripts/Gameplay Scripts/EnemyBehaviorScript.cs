using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviorScript : MonoBehaviour {

    [SerializeField]
    private Transform enemyParent;

    [SerializeField]
    private Transform basicEnemyPrefab;

    private void Awake() {
        
    }
    
    public void spawnBasicEnemy(EnemyBeat beat) {
        float randomY = Random.Range(-5f, 5f);
        Transform createBomb = Instantiate(basicEnemyPrefab, new Vector3(6f, randomY, 0f), Quaternion.identity);
        createBomb.parent = enemyParent;
    }
	
    public void spawnVertSlash(EnemyBeat beat) {
        print("Enemy - Vertical Slash");
    }

    public void spawnHorzSlash(EnemyBeat beat) {
        print("Enemy - Horizontal Slash");
    }
}
