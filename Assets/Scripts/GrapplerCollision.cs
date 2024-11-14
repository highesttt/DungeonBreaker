using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GrapplerCollision : MonoBehaviour {
    private static IEnumerator WaitForSeconds(int seconds, int scene) {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(scene);
    }

    void OnTriggerEnter2D(Collider2D other) {
        Grappler.isLaunched = false;

        if (other.gameObject.CompareTag("Ball")) {
            Ball ball = other.GetComponent<Ball>();
            if (ball.Split() == true) {
                StartCoroutine(WaitForSeconds(2, SceneManager.GetActiveScene().buildIndex + 1));
            }
        }
    }
}
