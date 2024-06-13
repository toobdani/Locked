using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue
{
    //This array will contain the names of the characters saying stuff in the dialogue
    public string[] name;

    //This array will contain what the characters say in teh dialogue
    public string[] sentances;

    //These arrays store what images need to appear during the dialogue on the left and right sides of the dialogue box.
    public GameObject[] leftimages;
    public GameObject[] rightimages;

    public string tag;

}
