using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour
{

    [SerializeField] Animator BottomDrawer;

    [SerializeField] bool open;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(open == true)
        {
            BottomDrawer.SetBool("Open", true);
        }
    }
}
