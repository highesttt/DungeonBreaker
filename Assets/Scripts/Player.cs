using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public float speed = 3.0f;
    public Rigidbody2D rb;

    public AudioSource death;
    public AudioClip deathSound;
    private float movement;

    void Update() {
        float x = Input.GetAxis("Horizontal");
        movement = x * speed;

        // depending on the direction the player is moving, flip the sprite
        if (movement > 0) {
            transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
        } else if (movement < 0) {
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + new Vector2(movement * Time.fixedDeltaTime, 0));
    }

    void OnCollisionEnter2D(Collision2D other) {

        Debug.Log("Collision with " + other.gameObject.tag);

        if (other.gameObject.CompareTag("Ball")) {
            Debug.Log("Game Over");
           // audioSource.PlayOneShot(collisionSound); // Play collision sound
            StartCoroutine(GrapplerCollision.WaitForSeconds(0, SceneManager.GetActiveScene().buildIndex));
        }

        if (other.gameObject.CompareTag("Powerup")) {
            HandlePowerup(other.gameObject);
            Destroy(other.gameObject);
        }
    }

    void HandlePowerup(GameObject powerup) {
        string powerupType = powerup.GetComponent<Powerup>().type;
        switch (powerupType) {
            case "SlowGrappler":
                Grappler.speed /= 1.2f;
                break;
            case "FastGrappler":
                Grappler.speed *= 1.2f;
                break;
            case "SkipLevel":
                StartCoroutine(GrapplerCollision.WaitForSeconds(1, SceneManager.GetActiveScene().buildIndex + 1));
                break;
            case "PlayerDies":
                death.PlayOneShot(deathSound); 
                StartCoroutine(GrapplerCollision.WaitForSeconds(1, SceneManager.GetActiveScene().buildIndex));
                break;
            case "SingleSplit":
                Ball.singleSplit = true;
                break;
        }
    }
}
