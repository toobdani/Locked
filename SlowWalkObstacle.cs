using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowWalkObstacle : MonoBehaviour
{
    [SerializeField] SafeWalk_Code SWC;

    [SerializeField] GameObject Startpoint;

    [SerializeField] GameObject Endpoint;

    [SerializeField] Animator Anim;

    [SerializeField] float wait;

    [SerializeField] float animwait;

    [SerializeField] GameObject Warning;

    [SerializeField] bool Movebool;

    [SerializeField] GameObject Lighter;

    [SerializeField] int ZipLayer;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        SWC = GameObject.FindGameObjectWithTag("Player").GetComponent<SafeWalk_Code>();
        //Warning.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Startpoint != null && Endpoint != null)
        {
            var Move = speed * Time.deltaTime;
            if (Movebool == true)
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Endpoint.transform.position, Move);
            }
            else if (Movebool == false)
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Startpoint.transform.position, Move);
            }

            if (gameObject.transform.position == Startpoint.transform.position)
            {
                Movebool = true;
            }
            else if (gameObject.transform.position == Endpoint.transform.position)
            {
                Movebool = false;
            }
        }
        else if(Anim != null)
        {
            wait += Time.deltaTime;

            Warning.SetActive(wait >= (animwait / 3) * 2 && wait != animwait);

            if (wait >= animwait)
            {
                StartCoroutine(AnimWait());
            }

        }
        else if(Lighter != null)
        {
            wait += Time.deltaTime;

            Warning.SetActive(wait >= (animwait / 3) * 2 && wait != animwait);

            if (wait >= animwait)
            {
                StartCoroutine(Lighters());
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (SWC.HurtBool == false)
            {
                StartCoroutine(SWC.HurtWait());
            }
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (SWC.HurtBool == false)
            {
                StartCoroutine(SWC.HurtWait());
            }
        }
    }

    IEnumerator AnimWait()
    {
        Anim.SetBool("Start", true);
        yield return new WaitForSeconds(0.5f);
        wait = 0;
        Anim.SetBool("Start", false);

    }

    IEnumerator Lighters()
    {
        gameObject.layer = 8;
        Warning.SetActive(false);
        Lighter.SetActive(true);
        yield return new WaitForSeconds(3f);
        wait = 0;
        gameObject.layer = 6;
        Lighter.SetActive(false);
    }
}
