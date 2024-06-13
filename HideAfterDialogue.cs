using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideAfterDialogue : MonoBehaviour
{
    [SerializeField] GameObject DialogueTrigger;

    [SerializeField] Request_Asking RA;
    // Start is called before the first frame update
    void Start()
    {
        RA = DialogueTrigger.GetComponent<Request_Asking>();
    }

    // Update is called once per frame
    void Update()
    {
        if(RA.Remove == true)
        {
            gameObject.SetActive(false);
        }
    }
}
