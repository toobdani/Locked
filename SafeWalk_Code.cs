using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeWalk_Code : MonoBehaviour
{
    public Transform MyTransform;

    //A Vector containing the position of the player's checkpoints, so that when they land on spikes they get respawned there
    public Vector4 Spawn;

    //A bool which when triggered allows the player to move across dangourous areas, but will decrease there speed
    public bool SafeWalk;

    //The playmovement script
    [SerializeField] private playmovement PM;

    //The data for the speed changes
    public float Maxspeed;
    public float Slowspeed;

    [SerializeField]bool WalkToggle;

    public bool Item;

    [SerializeField] Pickup PU;

    public bool HurtBool;

    //The sprites for the player so I can swap when they get hurt.
    [SerializeField] GameObject Sprites;
    [SerializeField] GameObject Hurt;

    public bool SlowCodeWork;

    [SerializeField] GameObject Key;

    [SerializeField]Request_Asking RA;

    [SerializeField] GameObject RegularLegs;

    [SerializeField] GameObject SlowLegs;

    [SerializeField] GameObject Button;

    void Start()
    {
        SafeWalk = false;

        MyTransform = GetComponent<Transform>();
        PM = GetComponent<playmovement>();
        PU = GetComponent<Pickup>();

        //Sets the spawn to the players start point upon the games start
        Spawn = MyTransform.position;

        //Sets the speed changes
        Maxspeed = PM.movespeed;
        Slowspeed = PM.movespeed / 1.5f;

        Sprites.SetActive(true);
        Hurt.SetActive(false);


        RA = Key.GetComponent<Request_Asking>();

        SlowCodeWork = false;
    }

    // Update is called once per frame
    void Update()
    {
        RegularLegs.SetActive(SafeWalk == false);
        SlowLegs.SetActive(SafeWalk);
        Button.SetActive(SlowCodeWork);

        if(SlowCodeWork == true)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                WalkToggle = !(WalkToggle);
            }
            //If the player holds shift they will be able to move over dangourous areas.
            if (WalkToggle == true && Item == false)
            {
                SafeWalk = true;
                PM.movespeed = Slowspeed;
                PM.SlowJump = true;
            }
            else if (WalkToggle == false && Item == false)
            {
                SafeWalk = false;
                PM.movespeed = Maxspeed;
                PM.SlowJump = false;
            }
        }
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Damage" && SafeWalk != true)
        {
            if(PU.PickedItem != null)
            {
                PU.Damaged = true;
            }
            if (HurtBool == false)
            {
                StartCoroutine(HurtWait());
            }
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Damage" && SafeWalk != true)
        {
            if (PU.PickedItem != null)
            {
                PU.Damaged = true;
            }
            if (HurtBool == false)
            {
                StartCoroutine(HurtWait());
            }
        }
    }

    public IEnumerator HurtWait()
    {
            HurtBool = true;
            PM.jump = true;
            Sprites.SetActive(false);
            Hurt.SetActive(true);
            PM.SlowJump = true;
            PM.StopMovement = true;
            yield return new WaitForSeconds(0.5f);
            Sprites.SetActive(true);
            Hurt.SetActive(false);
            PM.SlowJump = false;
            PM.StopMovement = false;
            WalkToggle = false;
            HurtBool = false;
            PU.Damaged = false;
            transform.position = Spawn;
        
    }

    public void SlowWalk()
    {
        WalkToggle = !(WalkToggle);
    }


}
