using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviourPunCallbacks
{
    public int gameTimeSec = 300;
    private float _timeSpentSec = 0.0f;
    private Text _textUI;
    private bool _gameEnded = false;
    private ExitGames.Client.Photon.Hashtable customRoomProperties;
    public static readonly string PROP_GAME_TIMER_KEY = "gameTimer";
    private string before_textUI;
    private ScoreManager scoreManager;
    private WinnerPanel winnerPanel;

    // Start is called before the first frame update
    void Start()
    {
        this._textUI = this.GetComponent<Text>();
        this.scoreManager = GameObject.FindWithTag("ScoreManager").GetComponent<ScoreManager>();
        this.winnerPanel = GameObject.FindWithTag("WinnerPanel").GetComponent<WinnerPanel>();
    }

    // Update is called once per frame
    void Update()
    {
        this._timeSpentSec += Time.deltaTime;
        this.UpdateUI();

        // 経過時間をroomのCustomPropertyに保存する（後から入ってきたプレイヤーと経過時間を共有するため）
        // 画面に表示する経過時間に変更があった場合のみ以下を実行
        if (PhotonNetwork.InRoom && this.before_textUI != this._textUI.text)
        {
            // Room内のカスタムプロパティ取得
            this.customRoomProperties = PhotonNetwork.CurrentRoom.CustomProperties;

            // 経過時間をroomのCustomPropertyに保存    
            this.customRoomProperties[PROP_GAME_TIMER_KEY] = this._timeSpentSec;
            PhotonNetwork.CurrentRoom.SetCustomProperties(this.customRoomProperties);

            this.before_textUI = this._textUI.text;
        }
    }

    private void UpdateUI()
    {
        if (this._gameEnded) return;

        float remainedTime = this.gameTimeSec - this._timeSpentSec;
        if (remainedTime <= 0)
        {
            this._gameEnded = true;
            remainedTime = 0.0f;
            this.OnGameEnd();
        }
        int minute = (int)(remainedTime / 60);
        int second = (int)(remainedTime % 60);
        this._textUI.text = string.Format("{0:00}:{1:00}", minute, second);
    }

    // Roomに入った時に呼ばれるコールバック
    public override void OnJoinedRoom()
    {
        // Room内のカスタムプロパティ取得
        this.customRoomProperties = PhotonNetwork.CurrentRoom.CustomProperties;
        // ゲームの経過時間がCustomPropertyに存在するなら、それを読み込み自身の経過時間とする
        if (this.customRoomProperties[PROP_GAME_TIMER_KEY] != null)
        {
            this._timeSpentSec = (float)this.customRoomProperties[PROP_GAME_TIMER_KEY];
        }
    }

    public void OnGameEnd()
    {
        // そこまでぇいいい！
        // 勝負ありSE
        // 画面に勝者を表示
        var winners = this.scoreManager.GetWinnerNameList();
        this.winnerPanel.Animate(winners);
    }
}
