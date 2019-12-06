using System.Collections;
using System.Collections.Generic;
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
        if(Input.GetKeyDown(KeyCode.A)) {
			animator.SetTrigger("TuppariTrigger");
		}
    }
}
