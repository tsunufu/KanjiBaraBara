using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVReader : MonoBehaviour
{
    //CSVファイル
    TextAsset csvFile;
    //CSVの中身を入れるリスト
    List<string[]> csvDatas = new List<string[]>();

    // Start is called before the first frame update
    void Start()
    {
        //Resources下のCSV読み込み
        csvFile = Resources.Load("barabarakannji") as TextAsset;
        StringReader reader = new StringReader(csvFile.text);

        //","で分割し，１行ずつ読み込み
        //リストに追加
        while(reader.Peek() != -1)
        {
            //1行ずつ読み込み
            string line = reader.ReadLine();
            //","区切りでリストに追加
            csvDatas.Add(line.Split(','));
        }
        
        Debug.Log(csvDatas[0][1]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
