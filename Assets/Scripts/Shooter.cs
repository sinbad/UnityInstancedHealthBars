using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour {
    public Bullet BulletPrefab;
    public float FireInterval = 0.75f;
    public Vector2 VelocityRange = new Vector2(50, 100);
    public float AngleRange = 5;

    private void Start() {
        StartCoroutine(FirePeriodically());
    }

    IEnumerator FirePeriodically() {
        // Random initial fire
        yield return new WaitForSeconds(Random.Range(0, FireInterval));

        var wfs = new WaitForSeconds(FireInterval);
        while (true) {
            FireBullet();
            yield return wfs;
        }
    }

    private void FireBullet() {
        // In a real game we'd use pooling here
        var b = Instantiate<Bullet>(BulletPrefab, transform.position, transform.rotation);
        Vector3 dir = Quaternion.AngleAxis(Random.Range(-AngleRange, AngleRange), Vector3.up) * transform.forward;
        dir *= Random.Range(VelocityRange.x, VelocityRange.y);
        b.Fire(dir);
    }
}