using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    //Stores the item the player picked up
    public GameObject PickedItem;

    //An Empty Gameobject behind the player which the item follows
    public GameObject MoveZone;

    //stores what the character is currently touching
    public GameObject overitem;
    // Start is called before the first frame update

    //The speed in which the item follows the player
    public float speed;

    [SerializeField] SafeWalk_Code SWC;
    [SerializeField] playmovement PM;

    public bool Damaged;

    [SerializeField] Animator CawLegs;
    void Start()
    {
        SWC = gameObject.GetComponent<SafeWalk_Code>();
        PM = gameObject.GetComponent<playmovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Damaged == true)
        {
            PickedItem.transform.position = PickedItem.GetComponent<Item>().Spawn;

            PickedItem = null;

            SWC.Item = false;

            PM.movespeed = SWC.Maxspeed;
            PM.StopJump = false;

            CawLegs.SetBool("Moving", false);

            Damaged = false;

        }
            if(PickedItem != null)
            {

                SWC.Item = true;

                PM.movespeed = SWC.Slowspeed;
                PM.StopJump = true;
                CawLegs = PickedItem.GetComponentInChildren<Animator>();
                CawLegs.SetBool("Moving", true);
            }
            /*else if (PickedItem != null)
            {
                PickedItem = null;

                SWC.Item = false;

                PM.movespeed = SWC.Maxspeed;
                PM.StopJump = false;
                CawLegs = null;
                CawLegs.SetBool("Moving", false);
            }*/
        

        //Makes the item follow the player when picked up
        var Move = speed * Time.deltaTime;
        if (PickedItem != null)
        {
            PickedItem.transform.position = Vector3.MoveTowards(PickedItem.transform.position, MoveZone.transform.position, Move);
        }

    }
}
