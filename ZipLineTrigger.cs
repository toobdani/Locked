using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZipLineTrigger : MonoBehaviour
{
    //Sets the mechanics script
    [SerializeField] public ZipLine_Code Z;

    [SerializeField] private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Z = Player.GetComponent<ZipLine_Code>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
