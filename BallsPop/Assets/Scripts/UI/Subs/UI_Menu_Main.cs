using UnityEngine;
using UnityEngine.UI;

public class UI_Menu_Main : UI_Elements
{
    Button startGame;
    Button quitGame;

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
        quitGame.onClick.AddListener(() => sceneLoader.Quit_Game());
    }
}
