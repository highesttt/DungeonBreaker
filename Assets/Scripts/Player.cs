using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public float speed = 3.0f;
    public Rigidbody2D rb;
    private float movement;

    void Update() {
        float x = Input.GetAxis("Horizontal");
        movement = x * speed;
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + new Vector2(movement * Time.fixedDeltaTime, 0));
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Ball")) {
            Debug.Log("Game Over");

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
