using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpButton : MonoBehaviour
{
    // 自分の操作する力士
    private GameObject player;
    private bool isPush = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void PushDown()
    {
        this.isPush = true;
    }

    public void PushUp()
    {
        this.isPush = false;
    }

    // Update is called once per frame
    void Update()
    {
        // ボタン押下中は常にjump
        if(this.isPush){
            this.player.gameObject.GetComponent<CubeScript>().OnJump();
        } 
        
        if(this.player == null) {
            // tagがPlayerのものを全て取得
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        
            // 一つずつIsMineを確認
            foreach (var p in players) {
                if(p.gameObject.GetComponent<CubeScript>().IsMine){
                    this.player = p;
                    break;
                }
            }
        }
    }
}
