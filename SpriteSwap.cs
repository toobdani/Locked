using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSwap : MonoBehaviour
{

    public GameObject[] LeftSprites;

    public GameObject[] RightSprites;

    [SerializeField] private Dialogue_Manager DM;
    // Start is called before the first frame update
    void Start()
    {
        DM = gameObject.GetComponent<Dialogue_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject L in LeftSprites)
        {
            L.SetActive(DM.LeftShow == L);
        }

        foreach(GameObject R in RightSprites)
        {
            R.SetActive(DM.RightShow == R);
        }
    }
}
