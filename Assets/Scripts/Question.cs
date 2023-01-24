using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;
using System.Linq;
using DG.Tweening;

public class Question : MonoBehaviour
{
    //CSVファイル
    TextAsset csvFile;
    //CSVの中身を入れるリスト
    List<string[]> kannjiDatas = new List<string[]>();

    //private List<string> characters = new List<string>() { "青", "色", "有", "月" };

    private List<string> kannji = new List<string>();

    [SerializeField] private List<Transform> cellPivots;
    [SerializeField] private List<Cell> cells;

    private Cell cell;

    public TextFieldScript textFieldScript;
    //判定用テキスト
    private string answerLabel;
    public string AnswerLabel => answerLabel;

    private GameObject cellName;

    private void Start()
    {

        //Resources下のCSV読み込み
        csvFile = Resources.Load("barabarakannji") as TextAsset;
        StringReader reader = new StringReader(csvFile.text);

        //","で分割し，１行ずつ読み込み
        //リストに追加
        while (reader.Peek() != -1)
        {
            //1行ずつ読み込み
            string line = reader.ReadLine();
            //","区切りでリストに追加
            kannjiDatas.Add(line.Split(','));
        }

        //配列に漢字のデータを追加
        for(int i= 1; i < kannjiDatas.Count; i++)
        {
            kannji.Add(kannjiDatas[i][0]);
        }
        //"一"が出力されれば成功
        Debug.Log(kannji[0]);

        //開始時にも問題読み込み
        SetQuestion();
    }
    //StartButtonから参照したかったのでpublicに
    public void SetQuestion()
    {
        //ランダムに一つ漢字を選ぶ
        var str = kannji[Random.Range(0, kannji.Count)];
        //判定用
        answerLabel = str;
        //cellsの数(9回)だけforeachを回してあげて，textにstrの値を代入
        foreach(var c in cells)
        {
            c.Initialize(str, Hint);
            c.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        //shuffle
        var shuffle = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
        shuffle = shuffle.OrderBy(a => System.Guid.NewGuid()).ToList();
        //for (int i = 0; i < 50; i++)
        //{
        //    //ランダムで選ばれたcellを先頭に持ってくるという作業を50回繰り返してシャッフル
        //    cells[Random.Range(0, cells.Count)].transform.SetAsFirstSibling();
        //}
        for (int i = 0; i < cells.Count; i++)
        {
            cells[i].SetCurrentPosition(shuffle[i], cellPivots[shuffle[i]]);
        }
        Debug.Log(str);

        
    }
    //StartButtonから参照したかったのでpublicに
    public void AnswerQuestion()
    {
        /*
            foreach(var c in cells)
            {
                cells[c].transform.SetSiblingIndex(c);
            }
        */

        //cell移動のアニメーション
        //Scaleは変更できるが，GridLayoutGroupによってPositionが変更できなくなってしまっている
        //cells[0].GetComponent<RectTransform>().DOScale(new Vector3(2f, 2f), 3f);

        //cellの並び順を正しい順番に
        for (int i = 0; i < cells.Count; i++)
        {
            //SetSiblingIndexで指定したインデックスを指定
            //0から順番に昇順にソートしているので一度並べた位置が動くことはない
            //cells[i].transform.SetSiblingIndex(i);
            cells[i].SetCorrectPositionWithAnim(i, cellPivots[i]);
        }
    }

    public void Hint(Cell cell)
    {
        var changeCell = cells.Find(c => c.CurrentPosition == cell.Index);
        changeCell.SetCurrentPositionWithAnim(cell.CurrentPosition, cellPivots[cell.CurrentPosition]);
        cell.SetCurrentPositionWithAnim(cell.Index, cellPivots[cell.Index]);


        /*
        //クリックしたゲームオブジェクトを取得
        GameObject pointerObject = (data as PointerEventData).pointerClick;
        Debug.Log(pointerObject.name);
        //①
        //クリックしたオブジェクトのインデックスをiに代入
        cell = pointerObject.GetComponent<Cell>();
        int i = cell.Index;
        Debug.Log("クリックしたセルのインデックスは" + i);
        //クリックしたオブジェクトの順番取得
        Debug.Log("クリックしたセルの現在の順番は " + pointerObject.transform.GetSiblingIndex());
        int j = pointerObject.transform.GetSiblingIndex();
        Debug.Log(j);
        //②移動先のセルの順番取得
        cellName = GameObject.Find("Cell_" + j);
        Debug.Log("移動先のセルの名前は" + cellName);
        Debug.Log("移動先のセルの順序は " + cellName.transform.GetSiblingIndex());
        int k = cellName.transform.GetSiblingIndex();
        //③Cell_jを正しい位置に移動(クリックしたセルの位置に正しいオブジェクトを配置)
        cells[j].transform.SetSiblingIndex(j);
        //④Cell_iをもともとのCell_jの位置に移動(セルの交換)
        cells[i].transform.SetSiblingIndex(k);
        //セルの色を変更
        cells[j].GetComponent<Image>().color = new Color32(154, 205, 50, 255);
        */
    }
}
