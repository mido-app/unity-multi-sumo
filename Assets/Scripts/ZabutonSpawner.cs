using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;

public class ZabutonSpawner : MonoBehaviour
{
    public float spawnSpanMin = 10.0f;
    public float spawnSpanMax = 30.0f;
    public float spawnPointRadius = 10.0f;

    public Stack<GameObject> _inactiveZabutonList = new Stack<GameObject>();

    private float _nextSpawnSpan;
    private float _spendTimeAfterPrevSpawn = 0.0f;

    private void Start()
    {
        this._nextSpawnSpan = Random.Range(this.spawnSpanMin, this.spawnSpanMax);
    }

    // Update is called once per frame
    void Update()
    {
        if (!PhotonNetwork.IsMasterClient) return;

        this._spendTimeAfterPrevSpawn += Time.deltaTime;

        if (this._spendTimeAfterPrevSpawn >= this._nextSpawnSpan)
        {
            Debug.Log("Zabuton Spawn");
            var zabutonObj = this.GetOrCreateZabutonFromPool();
            var vector = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
            var unitVector = vector / Vector3.Magnitude(vector);
            var zabutonPosition = new Vector3(unitVector.x * spawnPointRadius, 1.5f, unitVector.z * spawnPointRadius);
            zabutonObj.transform.position = zabutonPosition;
            zabutonObj.SetActive(true);
            this._spendTimeAfterPrevSpawn = 0.0f;
            this._nextSpawnSpan = Random.Range(this.spawnSpanMin, this.spawnSpanMax);
        }
    }

    private GameObject GetOrCreateZabutonFromPool()
    {
        if (this._inactiveZabutonList.Count == 0)
        {
            var zabuton = PhotonNetwork.Instantiate("Zabuton", Vector3.zero, Quaternion.identity);
            zabuton.GetComponent<Zabuton>().SetZabutonSpawner(this);
            return zabuton;
        }
        else
        {
            return this._inactiveZabutonList.Pop();
        }
    }

    public void Deactivate(Zabuton zabuton)
    {
        this._inactiveZabutonList.Push(zabuton.gameObject);
        zabuton.gameObject.SetActive(false);
    }
}
