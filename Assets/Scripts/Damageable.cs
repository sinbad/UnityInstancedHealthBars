using UnityEngine;

public class Damageable : MonoBehaviour {
    public int MaxHealth;
    public float DamageForceThreshold = 1f;
    public float DamageForceScale = 5f;

    public int CurrentHealth { get; private set; }

    private void Start() {
        CurrentHealth = MaxHealth;
    }

    private void OnCollisionEnter(Collision other) {
        // Collision would usually be on another component, putting it all here for simplicity
        float force = other.relativeVelocity.magnitude;
        if (force > DamageForceThreshold) {
            CurrentHealth -= (int)((force - DamageForceThreshold) * DamageForceScale);
            CurrentHealth = Mathf.Max(0, CurrentHealth);
        }
    }
}