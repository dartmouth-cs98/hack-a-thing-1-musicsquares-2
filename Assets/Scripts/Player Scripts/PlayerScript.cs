using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    private SceneBehaviorScript sceneBehavior;

    private Vector2 matrixPosition;

    void Awake() {
        sceneBehavior = GameObject.FindGameObjectWithTag(Tags.SCENE_BEHAVIOR_TAG).GetComponent<SceneBehaviorScript>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        calculateKeyboardMovement();
	}

    void calculateKeyboardMovement() {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            transform.position = sceneBehavior.getSquarePosition(PlayerMovement.PLAYER_LEFT, matrixPosition);
        if (Input.GetKeyDown(KeyCode.RightArrow))
            transform.position = sceneBehavior.getSquarePosition(PlayerMovement.PLAYER_RIGHT, matrixPosition);
        if (Input.GetKeyDown(KeyCode.UpArrow))
            transform.position = sceneBehavior.getSquarePosition(PlayerMovement.PLAYER_UP, matrixPosition);
        if (Input.GetKeyDown(KeyCode.DownArrow))
            transform.position = sceneBehavior.getSquarePosition(PlayerMovement.PLAYER_DOWN, matrixPosition);
    }

    public void setMatrixPosition(Vector2 matrixPosition) {
        this.matrixPosition = matrixPosition;
    }
}
