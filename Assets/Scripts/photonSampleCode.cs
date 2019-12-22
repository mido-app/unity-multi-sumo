using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class photonSampleCode : MonoBehaviourPunCallbacks
{
    // MonoBehaviourではなくMonoBehaviourPunCallbacksを継承して、Photonのコールバックを受け取れるようにする    
    private void Start()
    {
        // PhotonServerSettingsに設定した内容を使ってマスターサーバーへ接続する
        PhotonNetwork.ConnectUsingSettings();
    }

    // マスターサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnConnectedToMaster()
    {
        RoomOptions roomOptions = new RoomOptions(); 
        // 全プレイヤーのUserIdを共有できるように設定
        roomOptions.PublishUserId = true;   

        // "room"という名前のルームに参加する（ルームが無ければ作成してから参加する）
        PhotonNetwork.JoinOrCreateRoom("room", roomOptions, TypedLobby.Default);
        PhotonNetwork.NickName = "empty";
        
    }

    // マッチングが成功した時に呼ばれるコールバック
    public override void OnJoinedRoom()
    {
        // マッチング後、ランダムな位置に自分自身のネットワークオブジェクトを生成する
        var v = new Vector3(Random.Range(-4.0f, 4.0f), 0.5f, Random.Range(-4.0f, 4.0f));
        var newPlayerObj = PhotonNetwork.Instantiate("Rikishi", v, Quaternion.identity);
        newPlayerObj.GetComponent<Renderer>().material.color = Random.ColorHSV();

        if (PhotonNetwork.InRoom)
        {
            // プレイヤーごとにfallCountなどの値をRoomのCustomPropertyに登録
            ExitGames.Client.Photon.Hashtable customRoomProperties = PhotonNetwork.CurrentRoom.CustomProperties;
            customRoomProperties[PhotonNetwork.LocalPlayer.UserId] = 0;
            PhotonNetwork.CurrentRoom.SetCustomProperties(customRoomProperties);
            // プレイヤー名登録
            PhotonNetwork.NickName = NameInputFieldScript.getPlayerName();
        }
    }

    private void Update(){
         
    }    
}
