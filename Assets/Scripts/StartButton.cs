using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public KanjiManager kanjiManager;
    public GameObject hanteiImage;
    public Text nextText;
    public static bool seikai;
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

        for (i = 0; i < seikaiKannjiArray.Length; i++)
        {
            seikaiKannjiArray[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Onclick()
    {
        SceneManager.LoadScene("Main");
    }
    //解答ボタン
    public void AnswerButton()
    {
        if (KanjiManager.hantei)
        {
            Debug.Log("正解");
            hanteiImage.SetActive(true);
            seikai = true;
            nextText.text = "次の問題へ";
            //正解用テキスト表示
            seikaiKannjiArray[kanjiManager.index].SetActive(true);
            if(kanjiManager.index == 3)
            {
                nextText.text = "タイトルへ";
            }
        }
        Debug.Log("解答ボタン");
    }
    //次へボタン
    public void GiveupButton()
    {
        if (KanjiManager.hantei)
        {
            hanteiImage.SetActive(false);
            //正解用テキスト非表示
            seikaiKannjiArray[kanjiManager.index].SetActive(false);
            kanjiManager.index++;
            seikai = false;
            //timeCounter.countdown = 60;
        }
        Debug.Log("答えを見る");
        if(KanjiManager.hantei == true && kanjiManager.index == 4)
        {
            SceneManager.LoadScene("Start");
        }
    }
}
