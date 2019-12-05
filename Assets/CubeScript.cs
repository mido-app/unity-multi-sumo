using Photon.Pun;
using UnityEngine;

public class CubeScript : MonoBehaviourPunCallbacks
{
    public float speed = 1.0f;
    public float jumpPower = 20.0f;
    public float buttobiPower = 50.0f;
    private Rigidbody rb;

    // プレイヤーのポジション
    private Vector3 Player_pos;

    public FixedJoystick fixedJoystick;

    // Start is called before the first frame update
    void Start()
    {
        var v = new Vector3(Random.Range(-4.0f, 4.0f), 0.5f, Random.Range(-4.0f, 4.0f));
        this.transform.position = v;
        this.GetComponent<Renderer>().material.color = Random.ColorHSV();

        this.rb = this.GetComponent<Rigidbody>();

        //最初の時点でのプレイヤーのポジションを取得
        Player_pos = GetComponent<Transform>().position;
    }
    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine) return;
        this.moveByRiditBody();
    }
    void moveByRiditBody()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(0, 0, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(0, 0, -speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(0, jumpPower, 0);
        }


        // ジョイコン操作時                
        Debug.Log("Horizontal : "+ fixedJoystick.Horizontal);
        Vector3 direction = (Vector3.forward * fixedJoystick.Vertical + Vector3.right * fixedJoystick.Horizontal)/30;
        rb.AddForce(direction * speed * Time.deltaTime, ForceMode.VelocityChange);


        //プレイヤーがどの方向に進んでいるかがわかるように、初期位置と現在地の座標差分を取得
        Vector3 diff = transform.position - Player_pos; 
        if (diff.magnitude > 0.01f) //ベクトルの長さが0.01fより大きい場合にプレイヤーの向きを変える処理を入れる(0では入れないので）
        {
            Quaternion lockRotation = Quaternion.LookRotation(diff, Vector3.up);
            lockRotation.x = 0;
            lockRotation.z = 0;
            transform.rotation = Quaternion.Lerp(transform.rotation, lockRotation, 0.1f);
            Player_pos = transform.position;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player") return;
        var vector = collision.gameObject.transform.position - this.transform.position;
        var unitVector = vector / Vector3.Magnitude(vector);
        var speedVector = unitVector * buttobiPower * Vector3.Magnitude(this.rb.velocity);
        collision.gameObject.GetComponent<Rigidbody>().AddForce(speedVector, ForceMode.Impulse);
    }
}