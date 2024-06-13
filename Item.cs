using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] Pickup PU;

    public bool AddItem = true;

    public Vector4 Spawn;
    // Start is called before the first frame update
    void Start()
    {
        AddItem = true;

        Spawn = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(AddItem == true)
            {
                PU.PickedItem = gameObject;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        PU.overitem = null;
    }
}
