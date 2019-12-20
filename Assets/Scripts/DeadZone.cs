using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private BoxCollider collaider;
    private ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        this.collaider = this.GetComponent<BoxCollider>();
        this.scoreManager = GameObject.FindWithTag("ScoreManager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");
        foreach (var p in players) {
            Vector3 pos = p.transform.position;
            // 原点からの距離が25を超えたプレイヤーは初期位置に戻す
            if (pos.magnitude > 25) {
                p.GetComponent<Rigidbody>().velocity = Vector3.zero;
                p.transform.position = new Vector3(Random.Range(-4.0f, 4.0f), 3f, Random.Range(-4.0f, 4.0f));
                if (p.GetComponent<CubeScript>().IsMine)
                {
                    this.scoreManager.AddFallCount();
                }
            }    
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.gameObject.transform.position = new Vector3(Random.Range(-4.0f, 4.0f), 3f, Random.Range(-4.0f, 4.0f));
            if (other.gameObject.GetComponent<CubeScript>().IsMine)
            {
                this.scoreManager.AddFallCount();
            }
        }
    }
}
