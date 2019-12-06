using UnityEngine;

public class TuppariScript : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.GetComponentInParent<CubeScript>().IsMine && Input.GetKeyDown(KeyCode.Z))
        {
            animator.SetTrigger("TuppariTrigger");
        }
    }
}
