using UnityEngine;
public class CubeScript : MonoBehaviour
{
    public float speed = 1.0f;
    public float jumpPower = 20.0f;
    public float buttobiPower = 50.0f;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        this.rb = this.GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if (this.name != "Rikishi") return;
        //this.moveByTransform();
        this.moveByRiditBody();
    }
    void moveByTransform()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
    }
    void moveByRiditBody()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(0, 0, speed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(0, 0, -speed);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(-speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(0, jumpPower, 0);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player") return;
        var vector = this.transform.position - collision.gameObject.transform.position;
        var unitVector = vector / Vector3.Magnitude(vector);
        var speedVector = unitVector * buttobiPower;
        collision.gameObject.GetComponent<Rigidbody>().AddForce(speedVector);
    }
}