using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public Vector2 startForce;

    public Rigidbody2D rb;

    public GameObject nextBall;

    public static bool singleSplit;

    void Start() {
        rb.AddForce(startForce, ForceMode2D.Impulse);
    }

    public bool Split() {

        // chance of 100%
        int chance = Random.Range(0, 100);

        if (chance < 25) {
            // drop powerup
            GameObject powerup = PowerupSpawner.Instance.SpawnPowerup();

            powerup.transform.position = rb.position;
        }

        if (nextBall != null) {
            if (singleSplit) {
                GameObject ball1 = Instantiate(nextBall, rb.position + Vector2.right / 4f, Quaternion.identity);
                Ball ball1Script = ball1.GetComponent<Ball>();
                ball1Script.startForce = new Vector2(ball1Script.startForce.x + 0.25f, 6f);
                singleSplit = false;
            } else {
                GameObject ball1 = Instantiate(nextBall, rb.position + Vector2.right / 4f, Quaternion.identity);
                GameObject ball2 = Instantiate(nextBall, rb.position + Vector2.left / 4f, Quaternion.identity);
                Ball ball1Script = ball1.GetComponent<Ball>();
                Ball ball2Script = ball2.GetComponent<Ball>();
                ball1Script.startForce = new Vector2(ball1Script.startForce.x + 0.25f, 6f);
                ball2Script.startForce = new Vector2(-(ball2Script.startForce.x + 0.25f), 6f);
            }
        }
        Destroy(gameObject);

        if (GameObject.FindGameObjectsWithTag("Ball").Length <= 1) {
            return true;
        }

        return false;
    }

}
