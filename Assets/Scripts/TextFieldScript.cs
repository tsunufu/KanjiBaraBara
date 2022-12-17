using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFieldScript : MonoBehaviour
{
    public InputField inputField;
    //テスト
    public Text answertext;
    //解答判定用
    public string myAnswer;

    // Start is called before the first frame update
    void Start()
    {
        inputField = inputField.GetComponent<InputField>();
        answertext = answertext.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InputText()
    {
        answertext.text = inputField.text;
        myAnswer = inputField.text;
    }
}
