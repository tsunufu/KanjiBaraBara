using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    public float countdown = 60;
    public ButtonManager buttonManager;

    public Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;

        timeText.text = "残り" + countdown.ToString("00") + "秒";

        if(countdown <= 0)
        {
            timeText.text = "時間になりました";
        }

        if (ButtonManager.seikai)
        {
            timeText.text = "正解！";
            countdown = 60;
        }
    }
}
