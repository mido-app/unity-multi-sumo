using UnityEngine;
using UnityEngine.UI;
using System.Collections;
 
public class NameInputFieldScript : MonoBehaviour
{
    private InputField inputField;
    public static string playerNamePrefKey = "";
    public GameObject startButton;

    void Start()
    {
        inputField = GetComponent<InputField>();
        startButton.GetComponent<Button>().interactable = false;
    }
 
    public void SetPlayerName()
    {
        playerNamePrefKey = inputField.text;

        if(playerNamePrefKey == "") {
            startButton.GetComponent<Button>().interactable = false;
        } else{
            startButton.GetComponent<Button>().interactable = true;
        }
    }   
}