using UnityEngine;

public class SEController : MonoBehaviour
{
    public AudioClip[] seClipList;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        this.audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayRandomAttackSE()
    {
        this.audioSource.PlayOneShot(this.seClipList[Random.Range(0, this.seClipList.Length - 1)]);
    }
}
