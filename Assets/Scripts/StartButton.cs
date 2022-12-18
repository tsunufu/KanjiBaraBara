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

    // Start is called before the first frame update
    void Start()
    {
        hanteiImage.SetActive(false);
        seikai = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Onclick()
    {
        SceneManager.LoadScene("Main");
    }

    public void AnswerButton()
    {
        if (KanjiManager.hantei)
        {
            Debug.Log("正解");
            hanteiImage.SetActive(true);
            seikai = true;
            nextText.text = "次の問題へ";
            if(kanjiManager.index == 3)
            {
                nextText.text = "タイトルへ";
            }
        }
        Debug.Log("解答ボタン");
    }

    public void GiveupButton()
    {
        if (KanjiManager.hantei)
        {
            hanteiImage.SetActive(false);
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
