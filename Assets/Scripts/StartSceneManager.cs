using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    [SerializeField] private Button startButton;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(ToMainScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void ToMainScene()
    //{
    //    SceneManager.LoadScene("Main");
    //}

    private void ToMainScene() => SceneManager.LoadScene("Main");
}
