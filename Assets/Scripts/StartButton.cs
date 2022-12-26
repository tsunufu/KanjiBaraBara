using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public Question question;
    public GameObject hanteiImage;
    public TextFieldScript textFieldScript;
    public Text nextText;
    public static bool seikai;
    //public bool Seikai => seikai;
    //public TimeCounter timeCounter;
    //正解用の配列
    public GameObject[] seikaiKannjiArray = new GameObject[4];
    //for文用
    int i;

    // Start is called before the first frame update
    void Start()
    {
        hanteiImage.SetActive(false);
        seikai = false;
    }

    public void Onclick()
    {
        SceneManager.LoadScene("Main");
    }
    //解答ボタン
    public void AnswerButton()
    {
        //正解判定
        if (textFieldScript.myAnswer == question.AnswerLabel)
        {
            Debug.Log("正解");
            seikai = true;
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
    public void GiveupButton()
    {
        if (seikai)
        {
            hanteiImage.SetActive(false);
            //新しい問題に
            question.SetQuestion();
            nextText.text = "答えを見る";
        }

        if (!seikai)
        {
            //解答表示
            question.AnswerQuestion();
            nextText.text = "次の問題へ";
        }

        seikai = false;
    }
}
