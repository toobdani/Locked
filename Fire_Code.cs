using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Code : MonoBehaviour
{

    //The fire gameobjects, with one for the left and right and one in general
    [SerializeField] private GameObject Fires;
    [SerializeField] private GameObject FireLeft;
    [SerializeField] private GameObject FireRight;

    //The playmovement script
    [SerializeField] private playmovement PM;

    public bool FireWork;

    [SerializeField] GameObject Button;

    // Start is called before the first frame update
    void Start()
    {
        PM = GetComponent<playmovement>();
        FireWork = false;
        Button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //checks what direction the player is and sets the fire to point that way
        FireLeft.SetActive(PM.moveValuesKeys.x < 0 || PM.moveValuesUI.x < 0);
        FireRight.SetActive(PM.moveValuesKeys.x > 0 || PM.moveValuesUI.x > 0);

        if(FireWork == true)
        {

            Button.SetActive(true);
            //Sets the fires on when holding the right click
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Fire();
            }
            else if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                FireUp();
            }
        }
    }

    public void Fire()
    {
        Fires.SetActive(true);
    }

    public void FireUp()
    {
        Fires.SetActive(false);
    }
}
