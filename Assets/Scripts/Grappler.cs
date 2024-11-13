using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappler : MonoBehaviour {

    public Transform player;
    public static Boolean isLaunched;

    public float speed = 26.0f;

    void Start() {
        isLaunched = false;
    }

    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            isLaunched = true;
        }

        if (isLaunched) {
            transform.localScale = transform.localScale + Vector3.up * Time.deltaTime * speed;
        } else {
            transform.position = player.position;
            transform.localScale = new Vector3(1, 0, 1);
        }
    }
}
