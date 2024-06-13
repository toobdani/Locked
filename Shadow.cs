using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    //A layermask which changes the things the raycast interacts with
    [SerializeField] private LayerMask ground;

    //The Shadow's position
    [SerializeField] private Transform ShadowTransform;


    // Update is called once per frame
    void Update()
    {
        RaycastHit Ghit;

        //This raycast is used to mark what's below the player and puts the shadow there
        Physics.Raycast(transform.position, Vector3.down, out Ghit, Mathf.Infinity, ground);
        ShadowTransform.position = Ghit.point + new Vector3(0, 0.1f, 0);

    }
}
