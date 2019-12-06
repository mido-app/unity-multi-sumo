using UnityEngine;

public class Zabuton : MonoBehaviour
{
    public float moveSpeedMin;
    public float moveSpeedMax;
    public float rotetionSpeed = 10f;

    public float _moveSpeed;
    public Vector3 _moveToward;

    // Start is called before the first frame update
    void Start()
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

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position == this._moveToward)
        {
            Destroy(this.gameObject);
        }
        this.transform.position = Vector3.MoveTowards(this.transform.position, this._moveToward, this._moveSpeed);
        this.transform.Rotate(new Vector3(0, this.rotetionSpeed, 0));
    }
}
