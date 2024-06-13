using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugCode : MonoBehaviour
{
    public GameObject DebugObject;

    public GameObject WrongObject;

    public int i;

    [SerializeField] public List<GameObject> Players;
    // Start is called before the first frame update
    void Start()
    {
        WrongObject.SetActive(false);
        foreach (GameObject G in GameObject.FindGameObjectsWithTag("Player"))
        {
            i++;
            Players.Add(G);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(i > 1)
        {
            WrongObject.SetActive(true);
        }
    }
}
