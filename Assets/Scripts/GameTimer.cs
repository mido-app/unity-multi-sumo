using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public int gameTimeSec = 300;
    private float _timeSpentSec = 0.0f;
    private Text _textUI;
    private bool _gameEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        this._textUI = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        this._timeSpentSec += Time.deltaTime;
        this.UpdateUI();
    }

    private void UpdateUI()
    {
        if (this._gameEnded) return;

        float remainedTime = this.gameTimeSec - this._timeSpentSec;
        if (remainedTime <= 0)
        {
            this._gameEnded = true;
            remainedTime = 0.0f;

        }
        int minute = (int)(remainedTime / 60);
        int second = (int)(remainedTime % 60);
        this._textUI.text = string.Format("{0:00}:{1:00}", minute, second);
    }
}
