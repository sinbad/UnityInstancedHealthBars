using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject SpawnPrefab;
    public int Rows;
    public int Cols;
    public Vector2 Spacing;

    private void Start() {
        Vector3 areaSize = new Vector3(Cols * Spacing.x, 0, Rows * Spacing.y);
        var baseCorner = transform.position - (areaSize * 0.5f);
        for (int y = 0; y < Rows; ++y) {
            for (int x = 0; x < Cols; ++x) {
                var pos = baseCorner + new Vector3(x * Spacing.x, 0, y * Spacing.y);
                Instantiate(SpawnPrefab, pos, Quaternion.AngleAxis(Random.Range(0,359), Vector3.up));
            }
        }
    }

}