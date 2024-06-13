using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide_drawFront : MonoBehaviour
{

    public GameObject draw_front;

    [SerializeField] EventsCode E;

    private void Start()
    {
        E = GameObject.FindGameObjectWithTag("CBlock").GetComponent<EventsCode>();
    }

    private void Update()
    {
        if(E.Paused == true)
        {
            draw_front.gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            draw_front.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            draw_front.gameObject.GetComponent<MeshRenderer>().enabled = true;
        }

    }

}
