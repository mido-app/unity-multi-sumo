using Photon.Pun;
using UnityEngine;

public class CubeScript : MonoBehaviourPunCallbacks
{
    public float speed = 1.0f;
    public float jumpPower = 20.0f;
    public float buttobiPower = 50.0f;
    private Rigidbody rb;
    private SEController seController;

    // 必殺技関連
    public static readonly string DEATHBLOW_NO_POWER = "DEATHBLOW_NO_POWER";
    public static readonly string DEATHBLOW_CAN_USE = "DEATHBLOW_CAN_USE";
    public static readonly string DEATHBLOW_USING = "DEATHBLOW_USING";
    private string deathBlowStatus = DEATHBLOW_NO_POWER;

    // スマホ フリック入力用 クリック位置のポジション
    private Vector3 touchStartPos;
	private Vector3 touchEndPos;
    private bool isTouch = false;

    // プレイヤーのポジション
    private Vector3 Player_pos;

    // 初期スケール
    private Vector3 defaultScale;

    public bool IsMine { get { return photonView.IsMine; } }
    public bool CanUseDeathBlow { get { return deathBlowStatus == DEATHBLOW_CAN_USE; }}

    // Start is called before the first frame update
    void Start()
    {
        this.rb = this.GetComponent<Rigidbody>();
        this.seController = GameObject.FindWithTag("SEController").GetComponent<SEController>();

        //最初の時点でのプレイヤーのポジションを取得
        Player_pos = GetComponent<Transform>().position;

        this.defaultScale = this.transform.localScale;
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
            this.OnJump();
        }
        if (Input.GetKey(KeyCode.X) && this.deathBlowStatus == DEATHBLOW_CAN_USE)
        {
            this.OnDeathblow();
        }

        // スマホ フリックでキャラクター移動
        if (Input.GetKeyDown (KeyCode.Mouse0) && !isTouch) {
            touchStartPos = new Vector3 (Input.mousePosition.x,
				0,
				Input.mousePosition.y);
		}
        if (Input.GetKey (KeyCode.Mouse0)) {
            touchEndPos = new Vector3 (Input.mousePosition.x,
				0,
				Input.mousePosition.y);
            isTouch = true;
            Vector3 mousePosDiff = touchEndPos - touchStartPos;
            if(mousePosDiff.magnitude > 0.01f){
                rb.AddForce(mousePosDiff / mousePosDiff.magnitude *  speed * Time.deltaTime);
            }
		}
		if (Input.GetKeyUp (KeyCode.Mouse0)) {
            isTouch = false;
		}

        //プレイヤーがどの方向に進んでいるかがわかるように、初期位置と現在地の座標差分を取得
        Vector3 diff = transform.position - Player_pos;
        if (diff.magnitude > 0.01f) //ベクトルの長さが0.01fより大きい場合にプレイヤーの向きを変える処理を入れる
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
        if (this.rb != null){
            var speedVector = unitVector * buttobiPower * Vector3.Magnitude(this.rb.velocity);
            collision.gameObject.GetComponent<Rigidbody>().AddForce(speedVector, ForceMode.Impulse);
        }
        // SEを鳴らす
        if (photonView.IsMine)
        {
            this.seController.PlayRandomAttackSE();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Zabuton" && this.deathBlowStatus == DEATHBLOW_NO_POWER)
        {
            this.deathBlowStatus = DEATHBLOW_CAN_USE;
            other.GetComponent<Zabuton>().Deactivate();
        }
    }

    public void OnJump(){
        rb.AddForce(0, jumpPower, 0);
    }

    public void OnDeathblow()
    {
        this.transform.localScale = this.defaultScale * 1.5f;
        this.deathBlowStatus = DEATHBLOW_USING;
        this.seController.PlayDeathblowSE();
        Invoke("OnDeathblowEnd", 5.0f);
    }

    private void OnDeathblowEnd()
    {
        this.deathBlowStatus = DEATHBLOW_NO_POWER;
        this.transform.localScale = this.defaultScale;
    }
}