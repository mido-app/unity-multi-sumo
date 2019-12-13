using UnityEngine;
using UnityEngine.UI;

public class FadeoutPanel : MonoBehaviour
{
    private Image _image;
    private bool _fadeOut;

    // Start is called before the first frame update
    void Start()
    {
        this._image = this.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!this._fadeOut) return;
        if (this._image.color.a >= 255) return;
        this._image.color = new Color(
            this._image.color.r,
            this._image.color.g,
            this._image.color.b,
            this._image.color.a + (0.4f * Time.deltaTime)
        );
    }

    public void StartFadeout()
    {
        this._fadeOut = true;
    }
}
