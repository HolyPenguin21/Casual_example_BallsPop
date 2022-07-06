using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PauseMenu : UI_Elements
{
    GameObject pauseButtonCanvas_obj, menuCanvas_obj;
    Button pauseButton, restart_button, resume_button;

    EventsHandler eventsHandler;

    public UI_PauseMenu(EventsHandler eventsHandler)
    {
        this.eventsHandler = eventsHandler;

        Set_PauseButtonObject(Get_Scene_CanvasObject(pauseButtonCanvas_obj, "PauseButton"));
        Set_PauseButton(Get_Scene_Button(pauseButton, "Pause"));

        Set_PauseMenuObject(Get_Scene_CanvasObject(menuCanvas_obj, "PauseMenu"));
        Set_RestartButton(Get_Scene_Button(restart_button, "Restart"));
        Set_ResumeButton(Get_Scene_Button(resume_button, "Resume"));

        Hide();
        Disable_PauseButton();

        eventsHandler.onGameStart += Enable_PauseButton;

        eventsHandler.onGameRestart += Hide;
        eventsHandler.onGameRestart += Enable_PauseButton;

        eventsHandler.onGameUnpause += Hide;
        eventsHandler.onGameUnpause += Enable_PauseButton;

        eventsHandler.onGameEnd += Disable_PauseButton;
    }

    #region Actions
    private void OpenCloseMenu()
    {
        if (menuCanvas_obj.activeInHierarchy)
        {
            Hide();
            Enable_PauseButton();
        }
        else
        {
            Show();
            Disable_PauseButton();
        }
    }

    public override void Hide()
    {
        menuCanvas_obj.SetActive(false);
    }

    public override void Show()
    {
        menuCanvas_obj.SetActive(true);

        eventsHandler.On_GamePause();
    }

    private void Disable_PauseButton()
    {
        pauseButton.interactable = false;
    }

    private void Enable_PauseButton()
    {
        pauseButton.interactable = true;
    }
    #endregion

    #region Setup
    #region Pause button
    public void Set_PauseButtonObject(GameObject obj)
    {
        pauseButtonCanvas_obj = obj;

        if (pauseButtonCanvas_obj == null)
        {
            pauseButtonCanvas_obj = MonoBehaviour.Instantiate(Resources.Load("UI/PauseMenu/PauseButton_Canvas", typeof(GameObject))) as GameObject;
        }
    }

    public void Set_PauseButton(Button button)
    {
        pauseButton = button;
        pauseButton.onClick.AddListener(OpenCloseMenu);
    }
    #endregion

    #region Pause menu
    public void Set_PauseMenuObject(GameObject obj)
    {
        menuCanvas_obj = obj;

        if (menuCanvas_obj == null)
        {
            menuCanvas_obj = MonoBehaviour.Instantiate(Resources.Load("UI/PauseMenu/PauseMenu_Canvas", typeof(GameObject))) as GameObject;
        }
    }

    public void Set_RestartButton(Button button)
    {
        restart_button = button;
        restart_button.onClick.AddListener(() => eventsHandler.On_GameRestart());
    }

    public void Set_ResumeButton(Button button)
    {
        resume_button = button;
        resume_button.onClick.AddListener(() => eventsHandler.On_GameUnpause());
    }
    #endregion
    #endregion
}
