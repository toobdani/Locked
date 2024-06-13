using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    [SerializeField] GameObject[] Objects;

    [SerializeField] GameObject Black;
    // Start is called before the first frame update
    void Start()
    {
        Black.SetActive(false);
        StartCoroutine(Credits());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator Credits()
    {
        Objects[0].SetActive(true);
        yield return new WaitForSeconds(5f);
        Objects[0].SetActive(false);
        Black.SetActive(true);
        Objects[1].SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Objects[2].SetActive(true);        
        yield return new WaitForSeconds(0.5f);
        Objects[3].SetActive(true);        
        yield return new WaitForSeconds(0.5f);
        Objects[4].SetActive(true);        
        yield return new WaitForSeconds(0.5f);
        Objects[5].SetActive(true);        
        yield return new WaitForSeconds(0.5f);
        Objects[6].SetActive(true);        
        yield return new WaitForSeconds(0.5f);
        Objects[7].SetActive(true);
        yield return new WaitForSeconds(3f);
        Objects[1].SetActive(false);
        Objects[2].SetActive(false);
        Objects[3].SetActive(false);
        Objects[4].SetActive(false);
        Objects[5].SetActive(false);
        Objects[6].SetActive(false);
        Objects[7].SetActive(false);
        Objects[8].SetActive(true);
        Objects[9].SetActive(true);
    }
}
