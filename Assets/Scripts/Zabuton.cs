using UnityEngine;

public class Zabuton : MonoBehaviour
{
    public float moveSpeedMin;
    public float moveSpeedMax;
    public float rotetionSpeed = 10f;

    private float _moveSpeed;
    private Vector3 _moveToward;

    private ZabutonSpawner _spawnBy;

    // Start is called before the first frame update
    void Start()
    {
        this.Activate();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position == this._moveToward)
        {
            this.Deactivate();
        }
        this.transform.position = Vector3.MoveTowards(this.transform.position, this._moveToward, this._moveSpeed);
        this.transform.Rotate(new Vector3(0, this.rotetionSpeed, 0));
    }

    public void SetZabutonSpawner(ZabutonSpawner spawner)
    {
        this._spawnBy = spawner;
    }

    public void Activate()
    {
        this._moveSpeed = Random.Range(this.moveSpeedMin, this.moveSpeedMax);
        var playerObjList = GameObject.FindGameObjectsWithTag("Player");
        var targetPlayer = playerObjList[Random.Range(0, playerObjList.Length - 1)];
        var directionVector = targetPlayer.transform.position - this.transform.position;
        directionVector.y = 0;
        var directionUnitVector = directionVector / Vector3.Magnitude(directionVector);
        this._moveToward = directionUnitVector * 30;
        this._moveToward.y = 1.5f;
    }

    public void Deactivate()
    {
        this._spawnBy.Deactivate(this);
    }
}
