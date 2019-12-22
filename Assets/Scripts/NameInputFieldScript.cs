using UnityEngine;
using UnityEngine.UI;
using System.Collections;
 
public class NameInputFieldScript : MonoBehaviour
{
    private InputField inputField;
    public static string playerName = "";
    public GameObject startButton;

    void Start()
    {
        inputField = GetComponent<InputField>();
        startButton.GetComponent<Button>().interactable = false;
    }

    public void setTextArea(string text) {
        inputField.text = text;
    }
 
    public void setPlayerName()
    {
        playerName = inputField.text;

        // プレイヤー名が入力されていない場合startボタンを非活性に
        if(playerName == "") {
            startButton.GetComponent<Button>().interactable = false;
        } else{
            startButton.GetComponent<Button>().interactable = true;
        }
    }   

    // 他シーンからプレイヤー名取得するためのgetter
    public static string getPlayerName() {
        return playerName;
    }
}