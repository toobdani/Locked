using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silofall : MonoBehaviour
{
    [SerializeField] Animator Fall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Drawer")
        {
            Fall.SetBool("Fall", true);
        }
    }
}
