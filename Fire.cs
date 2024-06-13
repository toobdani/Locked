using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    [SerializeField] woodcount W;

    [SerializeField] EventsCode EC;

    [SerializeField] playmovement PM;
    [SerializeField] Controls_Open CO;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PM = GameObject.FindGameObjectWithTag("Player").GetComponent<playmovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Wood")
        {
            Destroy(other.gameObject);
            Debug.Log("FWorking");
        }
        else if(other.gameObject.tag == "Bonfire")
        {
            other.GetComponent<Bonfire>().OnFire = true;
        }
        else if(other.gameObject.tag == "FinalWood")
        {
            other.GetComponent<Bonfire>().OnFire = true;
            EC.C = GameObject.FindGameObjectWithTag("MainCamera");
            EC.FinalFire();
        }
    }
}
