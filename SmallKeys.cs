using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallKeys : MonoBehaviour
{
    [SerializeField] Request_Asking[] RA;

    [SerializeField] GameObject[] Keys;

    // Start is called before the first frame update
    void Start()
    {
        Keys[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Keys[1].SetActive(RA[1].SmallKey == true);
        Keys[2].SetActive(RA[2].SmallKey == true);
    }
}
