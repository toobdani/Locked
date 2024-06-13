using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonfire : MonoBehaviour
{
    public bool OnFire;

    [SerializeField] GameObject Fire;

    [SerializeField] playmovement PM;

    [SerializeField] float UpSpeed;

    [SerializeField] GameObject[] Corpses;
    // Start is called before the first frame update
    void Start()
    {
        PM = GameObject.FindGameObjectWithTag("Player").GetComponent<playmovement>();
    }

    // Update is called once per frame
    void Update()
    {

        Fire.SetActive(OnFire);

        if(Corpses.Length != 0)
        {
            Corpses[0].SetActive(OnFire == false);
            Corpses[1].SetActive(OnFire == true);
        }    


    }

    private void OnTriggerStay(Collider other)
    {
        if (OnFire == true)
        {
            if(other.gameObject.tag == "Player")
            {
                PM.Myrigidbody.AddForce(Vector3.up * UpSpeed, ForceMode.Acceleration);
            }
        }
    }
}
