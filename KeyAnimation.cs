using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyAnimation : MonoBehaviour
{
    [SerializeField] private playmovement PM;

    [SerializeField] Animator Old;
    [SerializeField] Animator Sock;
    [SerializeField] Animator Edgy;
    // Start is called before the first frame update
    void Start()
    {
        PM = GameObject.FindGameObjectWithTag("Player").GetComponent<playmovement>();
    }

    // Update is called once per frame
    void Update()
    {
        Old.SetBool("Move", (PM.moveValuesKeys.x != 0 || PM.moveValuesKeys.z != 0) || (PM.moveValuesUI.x != 0 || PM.moveValuesUI.z != 0));
        Sock.SetBool("Move", (PM.moveValuesKeys.x != 0 || PM.moveValuesKeys.z != 0) || (PM.moveValuesUI.x != 0 || PM.moveValuesUI.z != 0));
        Edgy.SetBool("Move", (PM.moveValuesKeys.x != 0 || PM.moveValuesKeys.z != 0) || (PM.moveValuesUI.x != 0 || PM.moveValuesUI.z != 0));
    }
}
