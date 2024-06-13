using System.Collections;
using UnityEngine;

public class EventsCode : MonoBehaviour
{
    #region Player_Movement

    [Header("Player Movement")]

    [SerializeField] playmovement PM;

    #endregion

    #region Camera_Events

    [Header("Camera Events")]

    [SerializeField] float speed;

    public bool[] MoveCameraFar;

    [SerializeField] bool[] MoveCameraRegular;

    public bool Event;

    public GameObject C;

    public Vector3 RegularCamera;

    [SerializeField] GameObject[] CameraMove;

    [SerializeField] float speedmodifier = 1;

    #endregion

    #region Main_Menu
    [Header("Main Menu")]

    [SerializeField] Vector3 PlayerPosition;

    [SerializeField] bool StartTime = false;

    [SerializeField] GameObject MainMenuUI;
    #endregion

    #region Pause
    [Header("Pause")]

    public GameObject[] PauseMenu;

    public bool Paused;
    #endregion

    #region First_Drawer
    [Header("First Drawer")]

    [SerializeField] GameObject FirstDrawer;

    [SerializeField] Animator FirstDrawerAnimation;

    [SerializeField] Animator Silo;

    [SerializeField] GameObject FirstLock;

    [SerializeField] GameObject InvisibleWall;
    #endregion

    #region Second_Drawer
    [Header("Second Drawer")]
    [SerializeField] GameObject SecondDrawer;

    [SerializeField] Animator SecondDrawerAnimation;

    [SerializeField] GameObject SecondLock;

    Fire_Code FC;
    #endregion

    #region Fire_Sock
    [Header("Fire Sock")]

    public GameObject FireSock;

    public GameObject EdgyShadow;

    public GameObject Fire;

    [SerializeField] GameObject Edgy;

    [SerializeField] Animator EdgyMove;

    [SerializeField] GameObject White;

    [SerializeField] GameObject Spiral;

    [SerializeField] Dialogue D;

    [SerializeField] GameObject FireDialogueTrigger;

    [SerializeField] GameObject DeadSock;

    [SerializeField] private bool EdgyEventBool;

    [SerializeField] GameObject EdgyDialogue;
    #endregion
    
    #region Array_Number
    [Header("Array Number")]

    public int Arraynumber;
    #endregion

    #region SockOne
    [Header("SockOne")]
    [SerializeField] GameObject FirstSockSprites;

    [SerializeField] GameObject FirstSockDive;

    [SerializeField] Animator SockOne;

    [SerializeField] GameObject SockOneObject;

    [SerializeField] GameObject SockOneCollider;
    #endregion

    #region Controls
    [SerializeField] Controls_Open CO;

    [SerializeField] SafeWalk_Code SWC;


    #endregion

    #region Final_Event
    public Tutorial[] T;
    [SerializeField] Tutorial_Manager TM;
    [SerializeField] bool AddNewText;
    [SerializeField] Animator WardrobeEntrance;
    [SerializeField] GameObject Crowd;
    [SerializeField] Animator Left;
    [SerializeField] Animator Right;
    [SerializeField] GameObject[] GameUI;
    [SerializeField] GameObject EndUI;
    [SerializeField] bool tutorialAdd;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        PM = GameObject.FindGameObjectWithTag("Player").GetComponent<playmovement>();
        FC = GameObject.FindGameObjectWithTag("Player").GetComponent<Fire_Code>();
        SWC = GameObject.FindGameObjectWithTag("Player").GetComponent<SafeWalk_Code>();

        TM = GameObject.FindGameObjectWithTag("CBlock").GetComponent<Tutorial_Manager>();

        FirstDrawerAnimation = FirstDrawer.GetComponent<Animator>();

        Arraynumber = 9;

        InvisibleWall.SetActive(false);

        Edgy.SetActive(false);

        EdgyShadow.SetActive(false);

        Fire.SetActive(false);

        White.SetActive(false);

        DeadSock.SetActive(false);

        EdgyDialogue.SetActive(false);

        PauseMenu[0].SetActive(false);

        PauseMenu[1].SetActive(false);

        CO.Open = false;

        EndUI.SetActive(false);

        Crowd.SetActive(false);

        Menu();
    }

    // Update is called once per frame
    void Update()
    {
        var Move = speed * Time.deltaTime;

        float singleStep = speed * Time.deltaTime;

        #region Events
        if (C != null)
        {
            if(Event == true)
            {
                if (MoveCameraFar[Arraynumber] == true)
                {

                    C.transform.position = Vector3.MoveTowards(C.transform.position, CameraMove[Arraynumber].transform.position, Move * speedmodifier);
                }   
                else if (MoveCameraRegular[Arraynumber] == true)
                {
                    C.transform.localPosition = Vector3.MoveTowards(C.transform.localPosition, PlayerPosition, Move * speedmodifier);
                }

                if (C.transform.position == CameraMove[Arraynumber].transform.position)
                {
                    switch(Arraynumber)
                    {
                        case 0:
                            {
                                StartCoroutine(DrawerOneEvent());
                            }
                            break;
                        case 1:
                            {
                                StartCoroutine(DrawerOneEvent());
                            }
                            break;
                        case 2:
                            {
                                if (EdgyEventBool == false)
                                {
                                    StartCoroutine(EdgyEvent());
                                }
                            }
                            break;
                        case 4:
                            {
                                StartCoroutine(S());
                            }
                            break;
                        case 5:
                            {
                                StartCoroutine(DrawerTwoEvent());
                            }
                            break;
                        case 6:
                            {
                                PauseMenu[1].SetActive(true);
                            }
                            break;
                        case 7:
                            {
                                StartCoroutine(FinalEvent1());
                            }
                            break;                        
                        case 8:
                            {
                                StartCoroutine(FinalEvent1());
                            }
                            break;                        
                        case 9:
                            {
                                StartCoroutine(FinalEvent1());
                            }
                            break;
                    }
                  

                }
                else if (C.transform.localPosition == PlayerPosition && MoveCameraRegular[Arraynumber] == true)
                {
                    MoveCameraRegular[Arraynumber] = false;
                    PM.StopJump = false;
                    PM.StopMovement = false;
                    C.transform.localPosition = PlayerPosition;
                    Event = false;
                    C = null;
                    PauseMenu[0].SetActive(true);
                    speedmodifier = 1f;
                    Arraynumber = 9;
                    CO.Open = true;
                }
            }
            
        }
        #endregion

        #region Menu_Event
        if (StartTime == true)
        {
            if(C.transform.localPosition != PlayerPosition)
            {
                C.transform.localPosition = Vector3.MoveTowards(C.transform.localPosition, PlayerPosition, (Move * 8));
            }
            else
            {
                PM.StopJump = false;
                PM.StopMovement = false;
                C = null;
                StartTime = false;
                PauseMenu[0].SetActive(true);
                speedmodifier = 1f;
                CO.Open = true;
            }
        }
        #endregion
    }

    public IEnumerator S()
    {
        MoveCameraFar[Arraynumber] = false;
        yield return new WaitForSeconds(1f);
        MoveCameraRegular[Arraynumber] = true;
    }

    IEnumerator DrawerOneEvent()
    {
       if(Arraynumber == 0)
       {
            yield return new WaitForSeconds(0.5f);
            InvisibleWall.SetActive(true);
            Destroy(FirstLock);
            yield return new WaitForSeconds(0.1f);
            FirstDrawerAnimation.SetBool("Open", true);
            yield return new WaitForSeconds(2f);
            Silo.SetBool("Fall", true);
            yield return new WaitForSeconds(0.5f);
            MoveCameraFar[Arraynumber] = false;
            Arraynumber = 1;
            MoveCameraFar[Arraynumber] = true;
       }
       else if (Arraynumber == 1)
       {
           yield return new WaitForSeconds(0.5f);
           MoveCameraFar[Arraynumber] = false;
           MoveCameraRegular[Arraynumber] = true;
            SWC.SlowCodeWork = true;
        }
    }

    public IEnumerator EdgyEvent()
    {
        EdgyEventBool = true;
        yield return new WaitForSeconds(1f);
        MoveCameraFar[Arraynumber] = false;
        Arraynumber = 3;
        MoveCameraFar[Arraynumber] = true;
        yield return new WaitForSeconds(1f);
        EdgyShadow.SetActive(false);
        Edgy.SetActive(true);
        FireDialogueTrigger.SetActive(false);
        DeadSock.SetActive(true);
        FireSock.SetActive(false);
        White.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        White.SetActive(false);
        GameObject.FindGameObjectWithTag("CBlock").GetComponent<Dialogue_Manager>().StartDialogue(D);
    }

    public IEnumerator DS()
    {
        Destroy(SockOneCollider);
        SockOne.SetBool("Dive", true);
        yield return new WaitForSeconds(1.31f);
        FirstSockSprites.SetActive(false);
        FirstSockDive.SetActive(true);
        yield return new WaitForSeconds(2f);
        Destroy(SockOne);
        Destroy(FirstSockDive);
        Destroy(FirstSockSprites);
        Destroy(SockOneObject);
        FireSock.SetActive(true);

    }

    public void TutorialS()
    {
        SockOne.SetBool("Move", true);
    }

    public IEnumerator Wassup()
    {
        MoveCameraFar[3] = false;
        Spiral.SetActive(false);
        MoveCameraFar[Arraynumber] = false;
        MoveCameraRegular[Arraynumber] = true;
        EdgyMove.SetBool("Move", true);
        yield return new WaitForSeconds(0.5f);
        EdgyDialogue.SetActive(true);

    }

    IEnumerator DrawerTwoEvent()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(SecondLock);
        yield return new WaitForSeconds(0.1f);
        Crowd.SetActive(true);
        SecondDrawerAnimation.SetBool("Open", true);
        yield return new WaitForSeconds(2f);
        MoveCameraFar[Arraynumber] = false;
        MoveCameraRegular[Arraynumber] = true;
        FC.FireWork = true;
    }

    public void FinalFire()
    {
        PM.StopJump = true;
        PM.StopMovement = true;
        CO.Open = false;
        PauseMenu[0].SetActive(true);
        Event = true;
        Arraynumber = 7; 
        MoveCameraFar[Arraynumber] = true;
    }

    IEnumerator FinalEvent1()
    {
        MoveCameraFar[Arraynumber] = false;

        if(Arraynumber == 7)
        {
            if(tutorialAdd == false)
            {
                foreach (Tutorial t in T)
                {
                    if (TM.T.Count > 0)
                    {
                        if (AddNewText == false)
                        {
                            T[0].NewText = true;
                            AddNewText = true;
                        }
                    }
                    TM.T.Add(t);
                }
            }
            tutorialAdd = true;
            yield return new WaitForSeconds(0.5f);
            Arraynumber = 8;
            MoveCameraFar[Arraynumber] = true;
        }
        else if(Arraynumber == 8)
        {
            WardrobeEntrance.SetBool("Open", true);
            yield return new WaitForSeconds(0.5f);
            Arraynumber = 9;
            Crowd.SetActive(false);
            MoveCameraFar[Arraynumber] = true;
        }
        else if (Arraynumber == 9)
        {
            yield return new WaitForSeconds(0.5f);
            MoveCameraRegular[Arraynumber] = true;
        }
    }

    public IEnumerator FinalDrawer()
    {

        CO.Open = false;
        PM.StopJump = true;
        PM.StopMovement = true;
        Event = true;
        Paused = true;
        Arraynumber = 10;
        C = GameObject.FindGameObjectWithTag("MainCamera");
        speedmodifier = 10;
        MoveCameraFar[Arraynumber] = true;
        yield return new WaitForSeconds(5f);
        Left.SetBool("Open", true);
        Right.SetBool("Open", true);
        yield return new WaitForSeconds(3f);
        foreach(GameObject G in GameUI)
        {
            G.SetActive(false);
        }
        EndUI.SetActive(true);
    }    

    void Menu()
    {
        C = GameObject.FindGameObjectWithTag("MainCamera");
        C.transform.localPosition = CameraMove[6].transform.position;
        PM.StopJump = true;
        PM.StopMovement = true;
        MainMenuUI.SetActive(true);
    }

    public void StartButton()
    {
        StartTime = true;
        MainMenuUI.SetActive(false);
    }

    public void Pause()
    {
        C = GameObject.FindGameObjectWithTag("MainCamera");
        Paused = true;
        CO.Open = false;
        Event = true;
        PM.StopJump = true;
        PM.StopMovement = true;
        PauseMenu[0].SetActive(false);
        Arraynumber = 6;
        speedmodifier = 10f;
        MoveCameraFar[Arraynumber] = true;
    }

    public void Resume()
    {
        MoveCameraFar[Arraynumber] = false;
        MoveCameraRegular[Arraynumber] = true;
        PauseMenu[1].SetActive(false);
        StartCoroutine(ResumeWait());
    }

    IEnumerator ResumeWait()
    {
        yield return new WaitForSeconds(1.5f);
        CO.Open = true;
        Paused = false;
    }

    public void quit()
    {
        Application.Quit();
    }
}
