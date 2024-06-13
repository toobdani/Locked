using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls_Open : MonoBehaviour
{

    public bool Open;

    [SerializeField] Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Anim.SetBool("IsOpen", Open);
    }
}
