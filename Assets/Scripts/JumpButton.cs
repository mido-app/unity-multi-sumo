using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    public void OnClick()
    {
        // tagがPlayerのものを全て集める
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        // 一つずつIsMineを確認
        foreach (var player in players) {
            if(player.gameObject.GetComponent<CubeScript>().IsMine){
                Debug.Log("jump");
                player.gameObject.GetComponent<CubeScript>().OnJump();
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
