using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial_Box_Size : MonoBehaviour
{
    [SerializeField] RectTransform RC;

    [SerializeField] RectTransform Text;

    [SerializeField] Vector2 NewSize;
    // Start is called before the first frame update
    void Start()
    {
        RC = gameObject.GetComponent<RectTransform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        NewSize = new Vector2(Text.sizeDelta.x, 50);
        RC.sizeDelta = NewSize;
    }
}
