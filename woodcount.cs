using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class woodcount : MonoBehaviour
{

    public int Woodcount;

    [SerializeField] Request_Asking RA;
    // Start is called before the first frame update
    void Start()
    {
        RA = gameObject.GetComponent<Request_Asking>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Woodcount == 3)
        {
            RA.Task = true;
        }
    }
}
