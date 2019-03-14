using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPanel : MonoBehaviour
{
    public static MenuPanel instance { get; private set; }


    private CanvasGroup canvasGroup;
    private bool open;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (instance == null)
        {
            Debug.Log("Instancia no encontrada");
        }

        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OpenCloseInventory()
    {
        if (open)
        {
            ClosePanel();
            open = false;
        }
        else
        {
            open = true;
            OpenPanel();
        }
    }

    private void OpenPanel()
    {
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;

        Time.timeScale = 0;
    }

    private void ClosePanel()
    {
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;

        Time.timeScale = 1;

    }
}
