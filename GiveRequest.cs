using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveRequest : MonoBehaviour
{

    //A string which stores the name of the requested item
    [SerializeField] string Item;

    [SerializeField] Pickup P;
    [SerializeField] playmovement PM;
    [SerializeField] SafeWalk_Code SWC;

    [SerializeField] Request_Asking RA;

    [SerializeField] GameObject Debug;

    [SerializeField]GameObject G;


    private bool Collided;
    // Start is called before the first frame update
    void Start()
    {
        P = GameObject.FindGameObjectWithTag("Player").GetComponent<Pickup>();
        PM = GameObject.FindGameObjectWithTag("Player").GetComponent<playmovement>();
        SWC = GameObject.FindGameObjectWithTag("Player").GetComponent<SafeWalk_Code>();
        Debug = GameObject.FindGameObjectWithTag("CBlock").GetComponent<DebugCode>().DebugObject;

    }

    // Update is called once per frame
    void Update()
    {
        if(Collided == true)
        {
            RA.Task = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag == "Player")
        {
            if (P.PickedItem != null)
            {
                Debug.SetActive(true);
                if (P.PickedItem.tag == Item)
                {
                    P.PickedItem.transform.SetParent(gameObject.transform);
                    P.PickedItem.GetComponent<Item>().AddItem = false;
                    P.PickedItem.transform.localPosition = new Vector3(0, -1.15f, 0);
                    P.PickedItem = null;
                    SWC.Item = false;
                    PM.movespeed = SWC.Maxspeed;
                    PM.StopJump = false;
                    Collided = true;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.SetActive(false);
    }
}
