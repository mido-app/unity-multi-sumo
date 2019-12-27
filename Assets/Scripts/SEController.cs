using UnityEngine;

public class SEController : MonoBehaviour
{
    public AudioClip[] attackSeList;
    public AudioClip deathbloSeList;
    public AudioClip iyoponSe;
    public AudioClip dodonSe;
    public AudioClip ieeeeSe;

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

    public void PlayIyoponSE()
    {
        this.audioSource.PlayOneShot(this.iyoponSe);
    }

    public void PlayDodonSE()
    {
        this.audioSource.PlayOneShot(this.dodonSe);
    }

    public void PlayIeeeeSE()
    {
        this.audioSource.PlayOneShot(this.ieeeeSe);
    }
}
