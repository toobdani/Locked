using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mechanics : MonoBehaviour
{
    //Elements of the player's gameobject
    [SerializeField] private Rigidbody MyRigidbody;

    [SerializeField] private Transform MyTransform;

    //The mechanics for the ziplining mechanic


    //A bool which is called when a player enters a zipline collider
    public bool Zipbool;

    //A bool which is called when the player is in the ziplines wire's collision
    public bool Zipline;

    //A bool which is called when the player is holding E on the zipline
    [SerializeField] private bool zipping;

    //A vector which will call the position of the zipline's start when the player begins ziplining
    public Vector3 ZipPosition;

    public GameObject ZipParent;

    public Animator ZipAnim;

    //The speed at which the player moves down the zipline
    public float Zipspeed;

    public bool ZipEnd;


    //A Vector containing the position of the player's checkpoints, so that when they land on spikes they get respawned there
    [SerializeField] private Vector4 Spawn;

    //A bool which when triggered allows the player to move across dangourous areas, but will decrease there speed
    public bool SafeWalk;

    //The playmovement script
    [SerializeField] private playmovement PM;

    //The data for the speed changes
    [SerializeField]private float Maxspeed;
    [SerializeField] private float Slowspeed;

    //The fire gameobjects, with one for the left and right and one in general
    [SerializeField] private GameObject Fires;
    [SerializeField] private GameObject FireLeft;
    [SerializeField] private GameObject FireRight;

    // Start is called before the first frame update
    void Start()
    {
        SafeWalk = false;

        MyRigidbody = GetComponent<Rigidbody>();
        MyTransform = GetComponent<Transform>();
        PM = GetComponent<playmovement>();

        //Sets the spawn to the players start point upon the games start
        Spawn = MyTransform.position;

        //Sets the speed changes
        Maxspeed = PM.movespeed;
        Slowspeed = PM.movespeed / 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        //checks what direction the player is and sets the fire to point that way
        FireLeft.SetActive(PM.moveValuesKeys.x < 0 || PM.moveValuesUI.x < 0);
        FireRight.SetActive(PM.moveValuesKeys.x > 0 || PM.moveValuesUI.x > 0);

        //Sets the fires on when holding the right click
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Fires.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            Fires.SetActive(false);
        }
        //Fires.SetActive(Input.GetKeyDown(KeyCode.Q));

        //If the player holds 1 they will be able to move over dangourous areas.
        if(Input.GetKey(KeyCode.LeftShift))
        {
            SafeWalk = true;
            PM.movespeed = Slowspeed;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            SafeWalk = false;
            PM.movespeed = Maxspeed;
        }

        //This will check to see if the player is pressing the interaction button and whether they are next to a zipline
        if(Input.GetKey(KeyCode.E) && Zipbool)
        {
            //Changes the players position to the ziplines
            MyTransform.position = ZipPosition;

            MyRigidbody.velocity = Vector3.zero;
            MyTransform.SetParent(ZipParent.transform);

            ZipAnim.SetBool("Start", true);

            //Freezes the player's Y position so they don't fall whilst using the Zipline
            MyRigidbody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
            PM.StopMovement = true;

            //Sets zipping as true so the zipline can be activated
            zipping = true;
        }
        else if (Input.GetKeyUp(KeyCode.E) || ZipEnd == true)
        {
            //If the player lets go of the E button zipping will be set to false
            zipping = false;

            ZipEnd = false;
            MyTransform.SetParent(null);

            ZipAnim.SetBool("Start", false);
            //If the player lets go of the E button they will be able to fall again
            MyRigidbody.constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
            PM.StopMovement = false;
        }

        //Checks whether the player is colliding with the zipline and whether zipping is still true
    }

    private void OnCollisionEnter(Collision collision)
    {

        //When touching damaging objects collision you go back to spawn
        if (collision.gameObject.tag == "Damage" && !SafeWalk)
        {
            MyTransform.position = Spawn;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        //When touching damaging objects collision you go back to spawn
        if (collision.gameObject.tag == "Damage" && !SafeWalk)
        {
            MyTransform.position = Spawn;
        }
    }
}
