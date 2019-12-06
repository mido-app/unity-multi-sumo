using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{
    public void StartGame()
    {
        GameObject.FindGameObjectWithTag("SEController").GetComponent<SEController>().PlayIyoponSE();
        GameObject.FindGameObjectWithTag("FadeoutPanel").GetComponent<FadeoutPanel>().StartFadeout();
        Invoke("LoadNextScene", 4.5f);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
