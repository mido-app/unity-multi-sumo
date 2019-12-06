﻿using Photon.Pun;
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
        // "room"という名前のルームに参加する（ルームが無ければ作成してから参加する）
        PhotonNetwork.JoinOrCreateRoom("room", new RoomOptions(), TypedLobby.Default);
    }

    // マッチングが成功した時に呼ばれるコールバック
    public override void OnJoinedRoom()
    {
        // マッチング後、ランダムな位置に自分自身のネットワークオブジェクトを生成する
        // Debug.log("successssssss!!!!");
        var v = new Vector3(Random.Range(-4.0f, 4.0f), 0.5f, Random.Range(-4.0f, 4.0f));
        var newPlayerObj = PhotonNetwork.Instantiate("Rikishi", v, Quaternion.identity);
        newPlayerObj.GetComponent<Renderer>().material.color = Random.ColorHSV();
    }
}