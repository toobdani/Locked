using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZipLine_Code : MonoBehaviour
{
    [SerializeField] private Rigidbody MyRigidbody;

    [SerializeField] private Transform MyTransform;

    //A bool which is called when a player enters a zipline collider
    public bool Zipbool;

    //A vector which will call the position of the zipline's start when the player begins ziplining
    public Vector3 ZipPosition;

    public GameObject ZipParent;

    public Animator ZipAnim;

    //The speed at which the player moves down the zipline
    public float Zipspeed;

    public bool ZipEnd;

    public bool StopBoost;

    [SerializeField] Animator Legs;

    [SerializeField] int RegularLayer;

    [SerializeField] int ZipLayer;

    [SerializeField] int ZipCount;

    [SerializeField] GameObject Hat;


    //The playmovement script
    [SerializeField] private playmovement PM;


    void Start()
    {
        MyRigidbody = GetComponent<Rigidbody>();
        MyTransform = GetComponent<Transform>();
        PM = GetComponent<playmovement>();

        RegularLayer = LayerMask.NameToLayer("Player");
        ZipLayer = LayerMask.NameToLayer("ZipPlayer"); 
        
        Hat.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //This will check to see if the player is pressing the interaction button and whether they are next to a zipline
        if(ZipAnim != null)
        {
            if (Zipbool && Input.GetKeyDown(KeyCode.Space))
            {
   
                StopBoost = true;
                //Changes the players position to the ziplines
                MyTransform.position = ZipPosition;


                MyRigidbody.velocity = Vector3.zero;
                MyTransform.SetParent(ZipParent.transform);

                ZipAnim.SetBool("Start", true);

                //Freezes the player's Y position so they don't fall whilst using the Zipline
                MyRigidbody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
                PM.StopMovement = true;

                gameObject.layer = ZipLayer;

                Legs.SetBool("ZipLine", true);
                Hat.SetActive(true);
            }
            else if (ZipEnd == true)
            {
                StopBoost = false;
                ZipEnd = false;
                MyTransform.SetParent(null);

                gameObject.layer = RegularLayer;

                ZipAnim.SetBool("Start", false);
                //If the player lets go of the E button they will be able to fall again
                MyRigidbody.constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
                PM.StopMovement = false;
                Legs.SetBool("ZipLine", false);
                Hat.SetActive(false);
            }
        }
    }
}
