using UnityEngine;
using UnityEngine.UI;

public class UI_Menu_Main : UI_Elements
{
    Button startGame, quitGame;

    public UI_Menu_Main(SceneLoader sceneLoader)
    {
        Setup_StartButton(sceneLoader);
        Setup_QuitButton(sceneLoader);
    }

    private void Setup_StartButton(SceneLoader sceneLoader)
    {
        startGame = Get_Scene_Button(startGame, "StartGame");
        startGame.onClick.AddListener(() => sceneLoader.Load_GameScene());
    }

    private void Setup_QuitButton(SceneLoader sceneLoader)
    {
        quitGame = Get_Scene_Button(quitGame, "Quit");
        quitGame.onClick.AddListener(() => sceneLoader.QuitGame());
    }

    public override void Hide()
    {
        startGame.transform.root.gameObject.SetActive(false);
    }

    public override void Show()
    {
        startGame.transform.root.gameObject.SetActive(true);
    }
}
