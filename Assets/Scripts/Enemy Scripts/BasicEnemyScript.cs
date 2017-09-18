using UnityEngine;

public class BasicEnemyScript : MonoBehaviour {

    public float xSpeed = -8f;

    // Update is called once per frame
    void Update() {
        Vector3 temp = transform.position;
        if (temp.x > 10f || temp.x < -10f || temp.y > 10f || temp.y < -10f)
            Destroy(gameObject);

        temp.x += xSpeed * Time.deltaTime;
        transform.position = temp;
	}
}
