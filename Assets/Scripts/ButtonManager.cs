using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Question question;
    public Cell cell;
    public GameObject hanteiImage;
    public TextFieldScript textFieldScript;
    public Text nextText;
    public static bool seikai;
    //図鑑に記録する用のList
    private static List<List<string>> zukan = new List<List<string>>();
    public static List<List<string>> Zukan => zukan;


    [SerializeField] private Button AnswerButton;

    [SerializeField] private Button GiveupButton;
    //public bool Seikai => seikai;
    //public TimeCounter timeCounter;
    //正解用の配列
    //public GameObject[] seikaiKannjiArray = new GameObject[4];
    //for文用
    //int i;

    // Start is called before the first frame update
    void Start()
    {
        hanteiImage.SetActive(false);
        seikai = false;

        AnswerButton.onClick.AddListener(Answer);

        GiveupButton.onClick.AddListener(Giveup);
    }

    //public void Onclick()
    //{
    //    SceneManager.LoadScene("Main");
    //}
    //解答ボタン
    public void Answer()
    {
        seikai = false;
        //正解判定
        if (textFieldScript.myAnswer == question.AnswerLabel)
        {
            Debug.Log("正解");
            seikai = true;
            //図鑑に漢字を登録する
            List<string> Datas = new List<string>();
            Datas.Add(question.Grade);
            Datas.Add(question.AnswerLabel);
            zukan.Add(Datas);
        }
        if (seikai)
        {
            Debug.Log("正解");
            hanteiImage.SetActive(true);
            nextText.text = "次の問題へ";
            //解答表示
            question.AnswerQuestion();
        }
        Debug.Log("解答ボタン");
    }
    //次へボタン
    public void Giveup()
    {

        switch (seikai)
        {
            case true:
                hanteiImage.SetActive(false);
                //新しい問題に
                //cell.Next();
                question.SetQuestion();
                nextText.text = "答えを見る";
                seikai = false;
                break;

            case false:
                //解答表示
                question.AnswerQuestion();
                nextText.text = "次の問題へ";
                seikai = true;
                break;

        }
        Debug.Log("漢字図鑑の中身は" + zukan[0][1]);
        Debug.Log(zukan[0][0]);

    }

    public void Update()
    {
       
    }
}
