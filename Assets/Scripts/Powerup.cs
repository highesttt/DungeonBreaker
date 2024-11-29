using UnityEngine;

public class Powerup : MonoBehaviour {
    public string type;

    // when it reaches the bottom of the screen, destroy it
    void Update() {
        if (transform.position.y < -5) {
            Destroy(gameObject);
        }
    }
}
