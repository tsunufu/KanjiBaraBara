using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Question : MonoBehaviour
{
    private List<string> characters = new List<string>() { "青", "色", "有", "月" };

    [SerializeField] private List<Cell> cells;

    private Cell cell;

    private void Start()
    {
      
    }

    private void SetQuestion()
    {
        //ランダムに一つ漢字を選ぶ
        var str = characters[Random.Range(0, characters.Count)];
        //cellsの数(9回)だけforeachを回してあげて，textにstrの値を代入
        foreach(var c in cells)
        {
            c.SetText(str);
        }
        //shuffle
        for (int i = 0; i < 50; i++)
        {
            //ランダムで選ばれたcellを先頭に持ってくるという作業を50回繰り返してシャッフル
            cells[Random.Range(0, cells.Count)].transform.SetAsFirstSibling();
        }
    }

    private void AnswerQuestion()
    {
        /*
            foreach(var c in cells)
            {
                cells[c].transform.SetSiblingIndex(c);
            }
        */

        //cellの並び順を正しい順番に
        for(int i = 0; i < 9; i++)
        {
            //SetSiblingIndexで指定したインデックスを指定
            cells[i].transform.SetSiblingIndex(i);
        }
    }

    public void Hint(BaseEventData data)
    {
        //クリックしたゲームオブジェクトを取得
        GameObject pointerObject = (data as PointerEventData).pointerClick;
        Debug.Log(pointerObject.name);
        //クリックしたオブジェクトのインデックスをiに代入
        cell = pointerObject.GetComponent<Cell>();
        int i = cell.Index;
        //Debug.Log(this.cells[i]);
        Debug.Log(i);
        Debug.Log("検知");
        //クリックしたセルを正しい位置に移動させる
        cells[i].transform.SetSiblingIndex(i);

    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetQuestion();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            AnswerQuestion();
        }

        
    }
}
