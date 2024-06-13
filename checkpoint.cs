using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    [SerializeField] SafeWalk_Code SC;

    [SerializeField] Vector3 Checkpoint_Location;
    // Start is called before the first frame update
    void Start()
    {
        SC = GameObject.FindGameObjectWithTag("Player").GetComponent<SafeWalk_Code>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            SC.Spawn = Checkpoint_Location;
            Destroy(gameObject);
        }
    }
}
