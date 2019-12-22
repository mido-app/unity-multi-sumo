using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using System.Text;

public class ScoreManager : MonoBehaviourPunCallbacks
{
    public GameObject fallObject = null;
    private ExitGames.Client.Photon.Hashtable customRoomProperties;
    private Text fallText;

    // Start is called before the first frame update
    void Start()
    {
        fallText = fallObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PhotonNetwork.InRoom)
        {   
            // Room内のカスタムプロパティ取得
            customRoomProperties = PhotonNetwork.CurrentRoom.CustomProperties;    
            // Roomにいる全プレイヤーに対して以下を実施
            // プレイヤーのUserIDを取得 → UserIDに紐づけたfallCountを取得 → スコア表に表示
            StringBuilder displaySb = new StringBuilder();
            // 自分のプレイヤー情報をスコア表の一番上に表示
            displaySb.Append(PhotonNetwork.NickName + " Fall Count : " + customRoomProperties[PhotonNetwork.LocalPlayer.UserId] + "\n");
            foreach (var p in PhotonNetwork.PlayerListOthers){
                displaySb.Append(p.NickName + " Fall Count : " + customRoomProperties[p.UserId] + "\n");
            }
            Text fallText = fallObject.GetComponent<Text>();
            fallText.text = displaySb.ToString();         
        }
    }

    public void AddFallCount()
    {
        // UserIdに紐づいたfallCountを加算
        customRoomProperties = PhotonNetwork.CurrentRoom.CustomProperties;
        customRoomProperties[PhotonNetwork.LocalPlayer.UserId] = (int)customRoomProperties[PhotonNetwork.LocalPlayer.UserId] + 1;
        PhotonNetwork.CurrentRoom.SetCustomProperties(customRoomProperties);
    }

    // Roomに入った時に呼ばれるコールバック
    public override void OnJoinedRoom()
    {
        // Room内のカスタムプロパティ取得
        customRoomProperties = PhotonNetwork.CurrentRoom.CustomProperties;
    }
}
