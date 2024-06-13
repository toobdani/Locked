using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tutorial_Manager : MonoBehaviour
{

    public string TutorialText;

    public Animator TutorialAnimation;

    public GameObject tutorialSprites;

    [SerializeField] TextMeshProUGUI DialogueText;

    public GameObject nullG;

    [SerializeField]private bool SummonBox = true;

    [SerializeField] string tag = "null";

    [SerializeField] bool tutorialevent = false;

    public List<Tutorial> T;

    [SerializeField] EventsCode E;


    // Start is called before the first frame update
    void Start()
    {
        TutorialText = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(T.Count > 0)
        {
            if(SummonBox == true)
            {
                StartCoroutine(Tutorial());
            }
        }
    }

    IEnumerator Tutorial()
    {
        tag = T[0].tag;
        tutorialSprites = T[0].Sprite;
        DialogueText.text = T[0].Text;
        tutorialSprites.SetActive(true);
        SummonBox = false;
        TutorialAnimation.SetBool("Open", true);
        yield return new WaitForSeconds(1.5f);
        if (tag == "S" && tutorialevent == false)
        {
            tutorialevent = true;
            E.TutorialS();
            tag = null;
        }
        else if(tag == "F")
        {
            StartCoroutine(E.FinalDrawer());
            tag = null;
        }
        yield return new WaitForSeconds(1.5f);
        TutorialAnimation.SetBool("Open", false);
        TutorialText = null;
        yield return new WaitForSeconds(1f);
        tutorialSprites.SetActive(false);
        tutorialSprites = nullG;
        T.Remove(T[0]);

        if (T.Count == 0)
        {
            SummonBox = true;
            tag = "null";
            tutorialevent = false;
        }
        else if (T.Count > 0)
        {
            if (T[0].NewText == true)
            {
                yield return new WaitForSeconds(1f);
                StartCoroutine(Tutorial());
            }
            else
            {
                StartCoroutine(Tutorial());
            }
        }

    }
}
