using UnityEngine;

public class Bullet : MonoBehaviour {
    public float Lifespan = 4;
    Rigidbody rb;
    float lifeLeft;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    public void Fire(Vector3 velocity) {
        rb.AddForce(velocity, ForceMode.VelocityChange);
        lifeLeft = Lifespan;
    }

    private void FixedUpdate() {
        if (gameObject.activeSelf) {
            lifeLeft -= Time.deltaTime;
            if (lifeLeft <= 0) {
                // ofc you'd use pooling in a real game
                Destroy(gameObject);
            }
        }
    }
}