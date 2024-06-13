using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue_Manager : MonoBehaviour
{
    //A queue gameobject which contains the dialogue the characters will say
    private Queue<string> Statement;
    private Queue<string> Names;
    [SerializeField]public List<GameObject> Left;
    [SerializeField]public List<GameObject> Right;
    public GameObject LeftShow;
    public GameObject RightShow;
    public string tag;
    [SerializeField] TextMeshProUGUI NameText;
    [SerializeField] TextMeshProUGUI DialogueText;
    public Animator Animator;
    [SerializeField] playmovement PM;
    [SerializeField] EventsCode E;
    [SerializeField] GameObject Displaybutton;
    [SerializeField] Controls_Open CO;

    // Start is called before the first frame update
    void Start()
    {
        Statement = new Queue<string>();
        Names = new Queue<string>();

        PM = GameObject.FindGameObjectWithTag("Player").GetComponent<playmovement>();
        Displaybutton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("StartingDialogue");

        Displaybutton.SetActive(true);
        Animator.SetBool("IsOpen", true);

        Statement.Clear();
        Names.Clear();
        Left.Clear();
        Right.Clear();

        PM.StopJump = true;
        PM.StopMovement = true;

        CO.Open = false;

        E.PauseMenu[0].SetActive(false);

        tag = dialogue.tag;

        foreach (string sentance in dialogue.sentances)
        {
            Statement.Enqueue(sentance);
        }

        foreach (string name in dialogue.name)
        {
            Names.Enqueue(name);
        }

        foreach (GameObject L in dialogue.leftimages)
        {
            Debug.Log("Left");
            Left.Add(L);
        }

        foreach (GameObject R in dialogue.rightimages)
        {
            Right.Add(R);
        }

        DisplayNextSentance();
    }
    public void DisplayNextSentance()
    {
        if(Statement.Count == 0)
        {
            EndDialogue();
        }
        else
        {
            string sentance = Statement.Dequeue();
            string name = Names.Dequeue();
            LeftShow = Left[0];
            RightShow = Right[0];

            Left.Remove(Left[0]);
            Right.Remove(Right[0]);

            NameText.text = name;
            StopAllCoroutines();
            StartCoroutine(TypeSentance(sentance));
        }
    }

    void EndDialogue()
    {
        Debug.Log("End");
        Animator.SetBool("IsOpen", false);

        switch (tag)
        {
            case "S":
                {
                    E.Event = true;
                    E.Arraynumber = 0;
                    E.C = GameObject.FindGameObjectWithTag("MainCamera");
                    E.MoveCameraFar[E.Arraynumber] = true;
                }
                break;
            case "F":
                {
                    E.Event = true;
                    E.Arraynumber = 2;
                    E.C = GameObject.FindGameObjectWithTag("MainCamera");
                    E.MoveCameraFar[E.Arraynumber] = true;
                    E.EdgyShadow.SetActive(true);
                    E.Fire.SetActive(true);
                }
                break;
            case "DS":
                {
                    E.Event = true;
                    E.Arraynumber = 4;
                    E.C = GameObject.FindGameObjectWithTag("MainCamera");
                    E.MoveCameraFar[E.Arraynumber] = true;
                    StartCoroutine(E.DS());
                }
                break;
            case "W":
                {
                        E.Event = true;
                        E.Arraynumber = 4;
                        StartCoroutine(E.Wassup());
                }
                break;
            case "SD":
                {
                    E.Event = true;
                    E.Arraynumber = 5;
                    E.C = GameObject.FindGameObjectWithTag("MainCamera");
                    E.MoveCameraFar[E.Arraynumber] = true;
                }
                break;
            default:
                {
                    PM.StopJump = false;
                    PM.StopMovement = false;
                    E.PauseMenu[0].SetActive(true);
                    CO.Open = true;
                }
                break;
        }
        tag = "null";
        Displaybutton.SetActive(false);
        return;
        /*if (tag == "S")
        {
            E.Event = true;
            E.Arraynumber = 0;
            E.C = GameObject.FindGameObjectWithTag("MainCamera");
            E.MoveCameraFar[E.Arraynumber] = true;
        }       
        else if(tag == "F")
        {
            E.Event = true;
            E.Arraynumber = 2;
            E.C = GameObject.FindGameObjectWithTag("MainCamera");
            E.MoveCameraFar[E.Arraynumber] = true;
            E.EdgyShadow.SetActive(true);
            E.Fire.SetActive(true);

        }        
        else if(tag == "DS")
        {
            E.Event = true;
            E.Arraynumber = 4;
            E.C = GameObject.FindGameObjectWithTag("MainCamera");
            E.MoveCameraFar[E.Arraynumber] = true;
            StartCoroutine(E.DS());

        }        
        else if(tag == "W")
        {
            E.Event = true;
            E.Arraynumber = 4;
            StartCoroutine(E.Wassup());
        }        
        else if(tag == "SD")
        {
            E.Event = true;
            E.Arraynumber = 5;
            E.C = GameObject.FindGameObjectWithTag("MainCamera");
            E.MoveCameraFar[E.Arraynumber] = true;
        }
        else
        {
            PM.StopJump = false;
            PM.StopMovement = false;
            E.PauseMenu[0].SetActive(true);
            CO.Open = true;
        }*/
    }


    IEnumerator TypeSentance(string sentence)
    {
        DialogueText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            DialogueText.text += letter;
            yield return new WaitForSeconds(0.03f);
        }
    }
}
