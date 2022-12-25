using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    private Text label;
    [SerializeField] private int index;
    public int Index => index;

    private void Awake()
    {
        //cell直下のテキストを取得
        label = GetComponentInChildren<Text>();
    }

    //他スクリプトで参照するためpublic
    public void SetText(string text)
    {
        //labelに引数のtextを代入
        label.text = text;
    }


}
