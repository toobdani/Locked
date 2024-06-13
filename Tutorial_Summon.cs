using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Summon : MonoBehaviour
{
    [SerializeField] Tutorial_Manager TM;

    public Tutorial[] T;

    [SerializeField] bool AddNewText;

    // Start is called before the first frame update
    void Start()
    {
        TM = GameObject.FindGameObjectWithTag("CBlock").GetComponent<Tutorial_Manager>();
    }

    private void OnTriggerEnter(Collider other)
    {
            foreach (Tutorial t in T)
            {
                if(TM.T.Count > 0)
                {
                    if(AddNewText == false)
                    {
                        T[0].NewText = true;
                        AddNewText = true;
                    }
                }
                TM.T.Add(t);
            }
            Destroy(gameObject);
    }
}
