using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KanjiManager : MonoBehaviour
{
    public GameObject[] kannjiArray = new GameObject[4];
    int i;
    public int index;
    public TextFieldScript textFieldScript;
    public static bool hantei = false;

    // Start is called before the first frame update
    void Start()
    {
        for (i = 0; i < kannjiArray.Length; i++)
        {
            kannjiArray[i].SetActive(false);
        }

        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (index == 0)
        {
            kannjiArray[index].SetActive(true);
            if(textFieldScript.myAnswer == "久")
            {
                //Debug.Log("正解");
                hantei = true;
                Debug.Log(hantei);
            }
        }
        if (index == 1)
        {
            hantei = false;
            kannjiArray[index].SetActive(true);
            if (textFieldScript.myAnswer == "今")
            {
                //Debug.Log("正解");
                hantei = true;
                Debug.Log(hantei);
            }
        }
        if (index == 2)
        {
            hantei = false;
            kannjiArray[index].SetActive(true);
            if (textFieldScript.myAnswer == "高")
            {
                //Debug.Log("正解");
                hantei = true;
                Debug.Log(hantei);
            }
        }
        if (index == 3)
        {
            hantei = false;
            kannjiArray[index].SetActive(true);
            if (textFieldScript.myAnswer == "字")
            {
                //Debug.Log("正解");
                hantei = true;
                Debug.Log(hantei);
            }
        }

    }
}
