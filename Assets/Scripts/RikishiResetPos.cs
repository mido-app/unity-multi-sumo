using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RikishiResetPos : MonoBehaviour
{
    private ScoreManager scoreManager;
    private GameObject deadZone;

    // Start is called before the first frame update
    void Start()
    {
        this.scoreManager = GameObject.FindWithTag("ScoreManager").GetComponent<ScoreManager>();
        this.deadZone = GameObject.Find("Dead Zone");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = this.gameObject.transform.position;
        Vector3 size = this.gameObject.transform.localScale;
        
        // 原点からの距離が19を超えたプレイヤーは初期位置に戻す
        // また、おおよそdeadZoneオブジェクトのy座標に近づいたら初期位置に戻す
        if (pos.magnitude > 19 || (pos.y - size.y/2) < this.deadZone.gameObject.transform.position.y) {
            this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.gameObject.transform.position = new Vector3(Random.Range(-4.0f, 4.0f), 3f, Random.Range(-4.0f, 4.0f));
            this.scoreManager.AddFallCount();
        }
    }
}
