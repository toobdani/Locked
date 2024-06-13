using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Trigger : MonoBehaviour
{
    [SerializeField] GameObject MoveToward;

    [SerializeField] Animator LevelDesingChange;

    [SerializeField] playmovement PM;

    [SerializeField] GameObject MoveItem;

    [SerializeField] float speed;

    [SerializeField] bool NoTrigger;

    [SerializeField] bool MoveCameraFar;

    [SerializeField] bool MoveCameraRegular;

    [SerializeField] GameObject C;

    [SerializeField] Vector3 RegularCamera;

    [SerializeField] GameObject CameraMove;


    [SerializeField] Controls_Open CO;
    // Start is called before the first frame update
    void Start()
    {
        PM = GameObject.FindGameObjectWithTag("Player").GetComponent<playmovement>();
        MoveItem.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        var Move = speed * Time.deltaTime;

        if (C != null)
        {

            if (MoveCameraFar == true)
            {
                C.transform.position = Vector3.MoveTowards(C.transform.position, CameraMove.transform.position, Move);
            }
            else if (MoveCameraRegular == true)
            {
                C.transform.position = Vector3.MoveTowards(C.transform.position, RegularCamera, Move);
            }

            if (C.transform.position == CameraMove.transform.position)
            {
                if (gameObject.tag == "Cannon")
                {
                    LevelDesingChange.SetBool("Change", true);
                    StartCoroutine(CameraPause());
                }
                else
                {
                    StartCoroutine(CameraPause());
                }
            }
            else if (C.transform.position == RegularCamera)
            {
                CO.Open = true;
                MoveCameraRegular = false;
                PM.StopJump = false;
                PM.StopMovement = false;
                C.transform.position = RegularCamera;
                C = null;
            }
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && NoTrigger != true)
        {
                C = GameObject.FindGameObjectWithTag("MainCamera");
                SwitchEffect();
        }
    }


    IEnumerator CameraPause()
    {
        yield return new WaitForSeconds(3f);
        MoveCameraFar = false;
        MoveCameraRegular = true;
    }
    void SwitchEffect()
    {
        CO.Open = false;
        NoTrigger = true;
        gameObject.transform.position = MoveToward.transform.position;
        MoveItem.SetActive(true);
        RegularCamera = C.transform.position;
        PM.StopJump = true;
        PM.StopMovement = true;
        MoveCameraFar = true;
        if(gameObject.tag != "Cannon")
        {
            LevelDesingChange.SetBool("Change", true);
        }
    }

    
}
