using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GrapplerCollision : MonoBehaviour {
    public AudioSource ballPop;
    public AudioClip popSound;
    public static IEnumerator WaitForSeconds(int seconds, int scene) {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(scene);
        Grappler.speed = 26.0f;
        Ball.singleSplit = false;
    }

    void OnTriggerEnter2D(Collider2D other) {
        Grappler.isLaunched = false;

        if (other.gameObject.CompareTag("Ball")) {
            Ball ball = other.GetComponent<Ball>();
            ballPop.PlayOneShot(popSound);
            if (ball.Split() == true) {
                StartCoroutine(WaitForSeconds(2, SceneManager.GetActiveScene().buildIndex + 1));
            }
        }
        if (other.gameObject.CompareTag("Powerup")) {
            //Add a sound here when laser hits the ball

            

            Destroy(other.gameObject);
        }
    }
}
