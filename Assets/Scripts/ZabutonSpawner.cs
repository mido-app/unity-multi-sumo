using UnityEngine;

public class ZabutonSpawner : MonoBehaviour
{
    public GameObject zabutonPrehub;
    public float spawnSpanMin = 10.0f;
    public float spawnSpanMax = 30.0f;
    public float spawnPointRadius = 10.0f;

    private float _nextSpawnSpan;
    private float _spendTimeAfterPrevSpawn = 0.0f;

    private void Start()
    {
        this._nextSpawnSpan = Random.Range(this.spawnSpanMin, this.spawnSpanMax);
    }

    // Update is called once per frame
    void Update()
    {
        this._spendTimeAfterPrevSpawn += Time.deltaTime;

        if (this._spendTimeAfterPrevSpawn >= this._nextSpawnSpan)
        {
            var zabutonObj = GameObject.Instantiate(this.zabutonPrehub);
            var vector = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
            var unitVector = vector / Vector3.Magnitude(vector);
            zabutonObj.transform.position = new Vector3(unitVector.x * spawnPointRadius, 1.5f, unitVector.z * spawnPointRadius);
            this._spendTimeAfterPrevSpawn = 0.0f;
            this._nextSpawnSpan = Random.Range(this.spawnSpanMin, this.spawnSpanMax);
        }
    }
}
