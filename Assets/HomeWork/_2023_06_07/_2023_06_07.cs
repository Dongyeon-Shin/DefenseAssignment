using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class _2023_06_07 : MonoBehaviour
{
    private EventSystem eventSystem;

    private Canvas popUpCanvas;
    private Stack<_2023_06_07_PopUpUI> popUpStack;
    private Canvas windowCanvas;
    private Canvas inGameCanvas;

    private void Awake()
    {
        eventSystem = GameManager.Resource.Instantiate<EventSystem>("UI/EventSystem");
        eventSystem.transform.parent = transform;

        popUpCanvas = GameManager.Resource.Instantiate<Canvas>("UI/Canvas");
        popUpCanvas.gameObject.name = "PopUpCanvas";
        popUpCanvas.sortingOrder = 100;
        popUpStack = new Stack<_2023_06_07_PopUpUI>();

        windowCanvas = GameManager.Resource.Instantiate<Canvas>("UI/Canvas");
        windowCanvas.gameObject.name = "WindowCanvas";
        windowCanvas.sortingOrder = 10;

        inGameCanvas = GameManager.Resource.Instantiate<Canvas>("UI/Canvas");
        inGameCanvas.gameObject.name = "InGameCanvas";
        inGameCanvas.sortingOrder = 1;
    }

    public T ShowPopUpUI<T>(T popUpUI) where T : _2023_06_07_PopUpUI
    {
        if (popUpStack.Count > 0)
        {
            _2023_06_07_PopUpUI prevUI = popUpStack.Peek();
            prevUI.gameObject.SetActive(false);
        }

        T ui = GameManager.Pool.GetUI<T>(popUpUI);
        ui.transform.SetParent(popUpCanvas.transform, false);
        popUpStack.Push(ui);

        Time.timeScale = 0f;
        return ui;
    }

    public T ShowPopUpUI<T>(string path) where T : _2023_06_07_PopUpUI
    {
        T ui = GameManager.Resource.Load<T>(path);
        return ShowPopUpUI(ui);
    }

    public void ClosePopUpUI()
    {
        _2023_06_07_PopUpUI ui = popUpStack.Pop();
        GameManager.Pool.ReleaseUI(ui.gameObject);

        if (popUpStack.Count > 0)
        {
            _2023_06_07_PopUpUI curUI = popUpStack.Peek();
            curUI.gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void ClearPopUpUI()
    {
        while (popUpStack.Count > 0)
        {
            ClosePopUpUI();
        }
    }

    public T ShowWindowUI<T>(T windowUI) where T : _2023_06_08_WindowUI
    {
        T ui = GameManager.Pool.GetUI(windowUI);
        ui.transform.SetParent(windowCanvas.transform, false);
        return ui;
    }

    public T ShowWindowUI<T>(string path) where T : _2023_06_08_WindowUI
    {
        T ui = GameManager.Resource.Load<T>(path);
        return ShowWindowUI(ui);
    }

    public void SelectWindowUI<T>(T windowUI) where T : _2023_06_08_WindowUI
    {
        windowUI.transform.SetAsLastSibling();
    }

    public void CloseWindowUI<T>(T windowUI) where T : _2023_06_08_WindowUI
    {
        GameManager.Pool.ReleaseUI(windowUI.gameObject);
    }
    public void ClearWindowUI()
    {
        _2023_06_08_WindowUI[] windows = windowCanvas.GetComponentsInChildren<_2023_06_08_WindowUI>();

        foreach (_2023_06_08_WindowUI windowUI in windows)
        {
            GameManager.Pool.ReleaseUI(windowUI.gameObject);
        }
    }
    public T ShowInGameUI<T>(T gameUi) where T : _2023_06_08_BuildUI
    {
        T ui = GameManager.Pool.GetUI(gameUi);
        ui.transform.SetParent(inGameCanvas.transform, false);

        return ui;
    }

    public T ShowInGameUI<T>(string path) where T : _2023_06_08_BuildUI
    {
        T ui = GameManager.Resource.Load<T>(path);
        return ShowInGameUI(ui);
    }

    public void CloseInGameUI<T>(T inGameUI) where T : _2023_06_08_BuildUI
    {
        GameManager.Pool.ReleaseUI(inGameUI.gameObject);
    }

    public void ClearInGameUI()
    {
        _2023_06_08_BuildUI[] inGames = inGameCanvas.GetComponentsInChildren<_2023_06_08_BuildUI>();

        foreach (_2023_06_08_BuildUI inGameUI in inGames)
        {
            GameManager.Pool.ReleaseUI(inGameUI.gameObject);
        }
    }
}
