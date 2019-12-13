using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathBrowButtonScript : MonoBehaviour
{
    // 自分の操作する力士
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void OnClick()
    {
        if(this.player != null){
            this.player.gameObject.GetComponent<CubeScript>().OnDeathblow();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(this.player != null){
            // 必殺技を使用できる場合のみ「Ｓ」ボタンを活性化
            this.GetComponent<Button>().interactable = this.player.gameObject.GetComponent<CubeScript>().CanUseDeathBlow;
        } else {
            this.GetComponent<Button>().interactable = false;
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

        



        // 座布団を取った場合、ボタンの色を活性化
        // this.GetComponent<Image>().Color = Color.black;
        /* if (hasZabuton) {

        }else{

        } */

    }
}
