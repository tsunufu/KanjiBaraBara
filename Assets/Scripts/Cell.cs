using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;

public class Cell : MonoBehaviour
{
    private Text label;
    [SerializeField] private int index;
    public int Index => index;

    private int currentPosition;
    public int CurrentPosition => currentPosition;

    //private Button button;

    private void Awake()
    {
        //cell直下のテキストを取得
        label = GetComponentInChildren<Text>();

        //button = gameObject.AddComponent<Button>();
    }


    //他スクリプトで参照するためpublic
    public void Initialize(string text, UnityAction<Cell> onClick)
    {
        //labelに引数のtextを代入
        label.text = text;
        var button = gameObject.AddComponent<Button>();
        //if (button == null)
        //{
        //    gameObject.AddComponent<Button>();
        //}
        button.onClick.AddListener(() =>
        {
            onClick(this);
        });
    }

    public void SetCurrentPosition(int position, Transform parent)
    {
        currentPosition = position;
        transform.SetParent(parent);
        transform.localPosition = Vector3.zero;
    }

    public void SetCurrentPositionWithAnim(int position, Transform parent)
    {
        currentPosition = position;
        transform.SetParent(parent);
        transform.DOLocalMove(Vector3.zero, 0.3f);
    }

    public void SetCorrectPositionWithAnim(int correctIndex, Transform parent)
    {
        currentPosition = correctIndex;
        transform.SetParent(parent);
        transform.DOLocalMove(Vector3.zero, 0.3f);
    }


}
