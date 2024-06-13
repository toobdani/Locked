using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] SafeWalk_Code SWC;

    [SerializeField] Pickup PU;

    [SerializeField] GameObject Debug;
    // Start is called before the first frame update
    void Start()
    {
        SWC = GameObject.FindGameObjectWithTag("Player").GetComponent<SafeWalk_Code>();
        PU = GameObject.FindGameObjectWithTag("Player").GetComponent<Pickup>();
        Debug = GameObject.FindGameObjectWithTag("CBlock").GetComponent<DebugCode>().DebugObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !SWC.SafeWalk)
        {

            if (PU.PickedItem != null)
            {
                PU.Damaged = true;
            }
            if (SWC.HurtBool == false)
            {
                StartCoroutine(SWC.HurtWait());
            }
        }
        else if (other.gameObject.tag == "Player" && gameObject.tag == "Socks")
        {
            if (PU.PickedItem != null)
            {
                PU.Damaged = true;
            }
            if (SWC.HurtBool == false)
            {
                StartCoroutine(SWC.HurtWait());
            }
        }
        Debug.SetActive(true);

    }

    private void OnTriggerStay(Collider other)
    {        
        if (other.gameObject.tag == "Player" && !SWC.SafeWalk)
        {
            if (PU.PickedItem != null)
            {
                PU.Damaged = true;
            }
            if (SWC.HurtBool == false)
            {
                StartCoroutine(SWC.HurtWait());
            }
        }
        else if (other.gameObject.tag == "Player" && gameObject.tag == "Socks")
        {
            if (PU.PickedItem != null)
            {
                PU.Damaged = true;
            }
            if (SWC.HurtBool == false)
            {
                StartCoroutine(SWC.HurtWait());
            }
        }
        Debug.SetActive(false);
    }
}
