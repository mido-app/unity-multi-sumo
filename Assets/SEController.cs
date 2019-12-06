using UnityEngine;

public class SEController : MonoBehaviour
{
    public AudioClip[] attackSeList;
    public AudioClip deathbloSeList;

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
        this.audioSource.PlayOneShot(this.attackSeList[Random.Range(0, this.attackSeList.Length - 1)]);
    }

    public void PlayDeathblowSE()
    {
        this.audioSource.PlayOneShot(this.deathbloSeList);
    }
}
