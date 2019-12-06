using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public Vector3 respawnPosition;
    private BoxCollider collaider;
    private ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        this.collaider = this.GetComponent<BoxCollider>();
        this.scoreManager = GameObject.FindWithTag("ScoreManager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.gameObject.transform.position = new Vector3(Random.Range(-4.0f, 4.0f), 3f, Random.Range(-4.0f, 4.0f));
            if (other.gameObject.GetComponent<CubeScript>().IsMine)
            {
                this.scoreManager.AddFallCount();
            }
        }
    }
}
