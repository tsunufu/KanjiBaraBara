using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    private GameObject PopupWindow;

    [SerializeField] private Button PopupButton;

    [SerializeField] private Button CloseButton;

    [SerializeField] private Button BackGroundButton;

    // Start is called before the first frame update
    void Start()
    {
        PopupWindow = GameObject.Find("Popup");

        PopupWindow.SetActive(false);

        PopupButton.onClick.AddListener(Popup);

        CloseButton.onClick.AddListener(Close);

        BackGroundButton.onClick.AddListener(Close);

    }

    private void Popup()
    {
        PopupWindow.SetActive(true);
    }

    private void Close()
    {
        PopupWindow.SetActive(false);
    }
}
