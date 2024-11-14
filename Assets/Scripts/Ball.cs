using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public Vector2 startForce;

    public Rigidbody2D rb;

    public GameObject nextBall;

    void Start() {
        rb.AddForce(startForce, ForceMode2D.Impulse);
    }

    public bool Split() {

        if (nextBall != null) {
            GameObject ball1 = Instantiate(nextBall, rb.position + Vector2.right / 4f, Quaternion.identity);
            GameObject ball2 = Instantiate(nextBall, rb.position + Vector2.left / 4f, Quaternion.identity);

            Ball ball1Script = ball1.GetComponent<Ball>();
            Ball ball2Script = ball2.GetComponent<Ball>();

            ball1Script.startForce = new Vector2(ball1Script.startForce.x + 0.25f, 6f);
            ball2Script.startForce = new Vector2(-(ball2Script.startForce.x + 0.25f), 6f);
        }
        Destroy(gameObject);

        if (GameObject.FindGameObjectsWithTag("Ball").Length == 1) {
            return true;
        }
        return false;
    }

}
