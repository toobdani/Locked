using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Request_Asking : MonoBehaviour
{
    //Contains the different things the character can say
    public Dialogue[] Say;

    public int RequestNumber;

    //The bool for whether this characters task is completed
    public bool Task;

    public bool Remove;

    public bool KeyRequest;

    public bool SmallKey;

    [SerializeField] GameObject Debug;
    // Start is called before the first frame update
    void Start()
    {
        Remove = false;
        SmallKey = false;
        Debug = GameObject.FindGameObjectWithTag("CBlock").GetComponent<DebugCode>().DebugObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.SetActive(true);
        if (other.gameObject.tag == "Player")
        {
                SpawnDialogue();
            
        }
    }

    private void SpawnDialogue()
    {
        //Changes the dialogue to the post task dialogue if the task has been completed.
        if(Task == true)
        {
            RequestNumber = 2;
        }

        //Triggers the dialogue
        GameObject.FindGameObjectWithTag("CBlock").GetComponent<Dialogue_Manager>().StartDialogue(Say[RequestNumber]);

        //Increases the request number if its the first dialogue
        if(RequestNumber == 0)
        {
            RequestNumber = 1;
        }

        if(RequestNumber == 2)
        {
            gameObject.SetActive(false);
            Remove = true;
            if(KeyRequest == true)
            {
                SmallKey = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.SetActive(false);
    }
}
