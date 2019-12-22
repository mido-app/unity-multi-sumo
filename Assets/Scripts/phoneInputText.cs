using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class phoneInputText : MonoBehaviour
{
    private Text nameText;
    public InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        this.nameText = this.GetComponent<Text>();
    }

    //ボタンタップ
    public void TouchButton()
    {
        // テキストエリアに名前登録
        this.inputField.GetComponent<NameInputFieldScript>().setTextArea(this.nameText.text);
    }
}
