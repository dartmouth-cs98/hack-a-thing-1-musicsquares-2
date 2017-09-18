using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBehaviorScript : MonoBehaviour {

    private EnemyBehaviorScript enemyBehavior;
    private VisualBehaviorScript visualBehavior;

    [SerializeField]
    private Transform squarePositionPrefab, squarePositionParent;

    [SerializeField]
    private Transform player;
    private PlayerScript playerScript;

    [SerializeField]
    private Camera mainCamera;

    private float squarePositionSpacing = 1.5f;
    private Transform[,] squarePositionMatrix;

    private void Awake() {
        playerScript = player.GetComponent<PlayerScript>();
        enemyBehavior = GetComponent<EnemyBehaviorScript>();
        visualBehavior = GetComponent<VisualBehaviorScript>();
    }

    public void Start() {
        loadSceneObjects(4, 0);
    }

    public void loadSceneObjects(int difficulty, int spawnMode) {
        spawnPositionSquares(difficulty);
        setCameraPosition(difficulty);
        bringInSquare(spawnMode);
    }

    public void spawnPositionSquares(int difficulty) {
        int squarePerDimension = 3 + difficulty;
        int middleNumber = Mathf.FloorToInt(squarePerDimension / 2f);
        bool oddDimension = (squarePerDimension%2 == 1) ? true : false;
        squarePositionMatrix = new Transform[squarePerDimension, squarePerDimension];
        
        for(int x = 0; x < squarePerDimension; x++) {
            for(int y = 0; y < squarePerDimension; y++) {
                if (oddDimension) {
                    Transform createPosSquare = Instantiate(squarePositionPrefab, 
                                                            new Vector3(squarePositionSpacing * (-middleNumber + x), squarePositionSpacing * (middleNumber - y), 0f), 
                                                            Quaternion.identity);
                    createPosSquare.parent = squarePositionParent;
                    squarePositionMatrix[x, y] = createPosSquare;
                }
                else {
                    Transform createPosSquare = Instantiate(squarePositionPrefab,
                                                            new Vector3(squarePositionSpacing * (-middleNumber + x) + (squarePositionSpacing / 2f), squarePositionSpacing * (middleNumber - y) - (squarePositionSpacing / 2f), 0f),
                                                            Quaternion.identity);
                    createPosSquare.parent = squarePositionParent;
                    squarePositionMatrix[x, y] = createPosSquare;
                }
            }
        }

        // Set Player to middle numbered square in matrix
        playerScript.setMatrixPosition(new Vector2(middleNumber, middleNumber));
        player.position = squarePositionMatrix[middleNumber, middleNumber].position;
    }

    public void setCameraPosition(int difficulty) {
        float z_pos = CameraPositions.DIFFICULTY_POS_UNKNOWN_Z;
        switch (difficulty) {
            case 0:
                z_pos = CameraPositions.DIFFICULTY_POS_0_Z;
                break;
            case 1:
                z_pos = CameraPositions.DIFFICULTY_POS_1_Z;
                break;
            case 2:
                z_pos = CameraPositions.DIFFICULTY_POS_2_Z;
                break;
            case 3:
                z_pos = CameraPositions.DIFFICULTY_POS_3_Z;
                break;
            case 4:
                z_pos = CameraPositions.DIFFICULTY_POS_4_Z;
                break;
        }

        mainCamera.transform.position = new Vector3(0f, 0f, z_pos);
    }

    public void bringInSquare(int spawnMode) {
        switch (spawnMode) {
            case 0:
                break;
        }
    }

	public void spawnEnemyBeat(EnemyBeat beat) {
        switch (beat.enemyType) {
            case BeatTypes.ENEMY_DEBUGBASIC:
                enemyBehavior.spawnBasicEnemy(beat);
                break;
            case BeatTypes.ENEMY_SLASH_VERT:
                enemyBehavior.spawnVertSlash(beat);
                break;
            case BeatTypes.ENEMY_SLASH_HORZ:
                enemyBehavior.spawnHorzSlash(beat);
                break;
        }
    }

    public void performVisualBeat(VisualBeat beat) {
        switch (beat.visualType) {
            case BeatTypes.VISUAL_GRID_PULSE:
                triggerSquarePositionPulse();
                break;
            case BeatTypes.VISUAL_FLASH_FOREGROUND_WEAK:
                visualBehavior.triggerForegroundFlash(0);
                break;
            case BeatTypes.VISUAL_FLASH_FOREGROUND_MEDIUM:
                visualBehavior.triggerForegroundFlash(1);
                break;
            case BeatTypes.VISUAL_FLASH_FOREGROUND_STRONG:
                visualBehavior.triggerForegroundFlash(2);
                break;
            case BeatTypes.VISUAL_FLASH_BACKGROUND_WEAK:
                visualBehavior.triggerBackgroundFlash(0);
                break;
            case BeatTypes.VISUAL_FLASH_BACKGROUND_MEDIUM:
                visualBehavior.triggerBackgroundFlash(1);
                break;
            case BeatTypes.VISUAL_FLASH_BACKGROUND_STRONG:
                visualBehavior.triggerBackgroundFlash(2);
                break;
        }
    }

    public void triggerSquarePositionPulse() {
        for(int x = 0; x < squarePositionMatrix.GetLength(0); x++) {
            for(int y = 0; y < squarePositionMatrix.GetLength(1); y++) {
                squarePositionMatrix[x, y].GetComponent<SquarePositionScript>().triggerPulse();
            }
        }
    }

    public Vector3 getSquarePosition(int direction, Vector2 matrixPosition) {
        switch (direction) {
            case PlayerMovement.PLAYER_UP:
                matrixPosition.y = (matrixPosition.y + squarePositionMatrix.GetLength(1) - 1) % squarePositionMatrix.GetLength(1);
                break;
            case PlayerMovement.PLAYER_DOWN:
                matrixPosition.y = (matrixPosition.y + squarePositionMatrix.GetLength(1) + 1) % squarePositionMatrix.GetLength(1);
                break;
            case PlayerMovement.PLAYER_LEFT:
                matrixPosition.x = (matrixPosition.x + squarePositionMatrix.GetLength(0) - 1) % squarePositionMatrix.GetLength(0);
                break;
            case PlayerMovement.PLAYER_RIGHT:
                matrixPosition.x = (matrixPosition.x + squarePositionMatrix.GetLength(0) + 1) % squarePositionMatrix.GetLength(0);
                break;
            default:
                return Vector3.zero;
        }
        playerScript.setMatrixPosition(matrixPosition);
        return squarePositionMatrix[(int)matrixPosition.x, (int)matrixPosition.y].position;
    }
}
