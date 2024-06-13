using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Cannon : MonoBehaviour
{

    [SerializeField] Request_Asking RA;
    // Start is called before the first frame update
    void Start()
    {
        //RA = GameObject.FindGameObjectWithTag("SKey").GetComponent<Request_Asking>();
    }

    // Update is called once per frame
    void Update()
    {
        RA.Task = true;
    }
}
