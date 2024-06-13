using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crowd_Boost : MonoBehaviour
{
    [SerializeField] bool Boost;

    [SerializeField] float Wait;

    [SerializeField] playmovement PM;
    [SerializeField] ZipLine_Code ZC;

    [SerializeField] float UpSpeed;

    [SerializeField] GameObject AddChildren;

    [SerializeField] Animator jumpAnim;
    // Start is called before the first frame update
    void Start()
    {
        PM = GameObject.FindGameObjectWithTag("Player").GetComponent<playmovement>();
        ZC = GameObject.FindGameObjectWithTag("Player").GetComponent<ZipLine_Code>();

        jumpAnim = AddChildren.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Wait += Time.deltaTime;

        if (Wait >= 3f && Boost == false)
        {
            Wait = 0;
            Boost = true;
            jumpAnim.SetBool("Jumping", true);
        }
        else if (Wait >=1f && Boost == true)
        {
            Wait = 0;
            Boost = false;
            jumpAnim.SetBool("Jumping", false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Boost == true && ZC.StopBoost == false)
        {
            if (other.gameObject.tag == "Player")
            {
                Debug.Log("Hello");
                PM.Myrigidbody.AddForce(Vector3.up * UpSpeed, ForceMode.Acceleration);
            }
        }
    }
}
