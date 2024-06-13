using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crowdmember : MonoBehaviour
{
    [SerializeField] Animator A;

    public float Speed;

    [SerializeField] SpriteRenderer SR;

    [SerializeField] float Red;
    [SerializeField] float Blue;
    [SerializeField] float Green;

    [SerializeField] crowdmember CM;
    // Start is called before the first frame update
    void Start()
    {
        A = gameObject.GetComponent<Animator>();
        SR = gameObject.GetComponent<SpriteRenderer>();
        if (CM == null)
        {
            Speed = Random.Range(1.0f, 3.0f);
            A.speed = Speed;

            Red = Random.Range(0.1f, 1.1f);
            Green = Random.Range(0.1f, 1.1f);
            Blue = Random.Range(0.1f, 1.1f);
            SR.color = new Color(Red, Green, Blue, 1);
        }


    }

    // Update is called once per frame
    void Update()
    {
        if(CM != null)
        {
            Speed = CM.Speed;
            A.speed = CM.Speed;
        }
    }
}
