using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappler : MonoBehaviour {

    public Transform player;
    public static Boolean isLaunched;
    public static float speed = 26.0f;
    public AudioSource audioSource; // Reference to Audio Source
    public AudioClip collisionSound;

    void Start() {
        isLaunched = false;
    }

    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            isLaunched = true;
            audioSource.PlayOneShot(collisionSound); // Play collision sound
        }

        if (isLaunched) {
            transform.localScale = transform.localScale + Vector3.up * Time.deltaTime * speed;
        } else {
            transform.position = player.position;
            transform.localScale = new Vector3(1, 0, 1);
        }
    }
}
