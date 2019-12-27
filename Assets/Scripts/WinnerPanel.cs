using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinnerPanel : MonoBehaviour
{
    private Image _image;
    private Text textConstant;
    private Text winenrNames;
    private SEController seController;
    private GameObject _backBtn;

    private List<string> winners;

    public string panelTitle = "今回の横綱";

    // Start is called before the first frame update
    void Start()
    {
        this._image = this.GetComponent<Image>();
        this._image.color = new Color(
            this._image.color.r,
            this._image.color.g,
            this._image.color.b,
            0
        );

        this.textConstant = GameObject.Find("WinnerTextConstant").GetComponent<Text>();
        this.textConstant.text = "";
        this.winenrNames = GameObject.Find("WinnerNames").GetComponent<Text>();
        this.winenrNames.text = "";

        this.seController = GameObject.FindWithTag("SEController").GetComponent<SEController>();
        this._backBtn = GameObject.Find("BackButton");
        this._backBtn.SetActive(false);
    }

    // Update is called once per frame
    public void Animate(List<string> winners)
    {
        this.winners = winners;
        this._image.color = new Color(
            this._image.color.r,
            this._image.color.g,
            this._image.color.b,
            200
        );
        Invoke("ShowTitle", 2.0f);
        Invoke("ShowWinners", 4.0f);
        this.seController.PlayDodonSE();
    }

    private void ShowTitle()
    {

        this.textConstant.text = this.panelTitle;
        this.seController.PlayDodonSE();
    }

    private void ShowWinners()
    {
        this.winenrNames.text = string.Join("\n", this.winners);
        this.seController.PlayIeeeeSE();
        this._backBtn.SetActive(true);
    }

    public void GoToTitleScene()
    {
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("Title");
    }
}
