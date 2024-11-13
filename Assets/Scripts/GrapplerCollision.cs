using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplerCollision : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other) {
        Grappler.isLaunched = false;

        if (other.gameObject.CompareTag("Ball")) {
            Ball ball = other.GetComponent<Ball>();
            ball.Split();
        }
    }
}
