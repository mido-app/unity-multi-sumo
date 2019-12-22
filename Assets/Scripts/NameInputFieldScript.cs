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
 
    public void SetPlayerName()
    {
        playerName = inputField.text;

        if(playerName == "") {
            startButton.GetComponent<Button>().interactable = false;
        } else{
            startButton.GetComponent<Button>().interactable = true;
        }
    }  

    public void getPlayerName(){
        return playerName;
    } 
}