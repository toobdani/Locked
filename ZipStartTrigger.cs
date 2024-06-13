using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZipStartTrigger : MonoBehaviour
{
    //Sets the mechanics script
    [SerializeField] public ZipLine_Code Z;

    //A Vector3 containing the position of the zipline, which will be set as the mechanics script's Zipposition upon collision
    [SerializeField]private Vector3 Zipposition;

    [SerializeField] private GameObject Player;

    [SerializeField] private GameObject ZipParent;


    // Start is called before the first frame update
    void Start()
    {
        Z = Player.GetComponent<ZipLine_Code>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //If the player enters the script's trigger it will set the mechanics script's zipposition and set the Zipbool as true
        if (other.gameObject.tag == "Player")
        {
            Z.ZipPosition = Zipposition;
            Z.ZipParent = ZipParent;
            Z.ZipAnim = ZipParent.GetComponent<Animator>();
            Z.Zipbool = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {

        //If you exit the script's trigger the zipbool will be made false and the mechanic script's zipposition will be set to default

        Z.Zipbool = false;
    }
}
