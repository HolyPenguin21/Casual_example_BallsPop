using UnityEngine;
using UnityEngine.UI;

public abstract class UI_Elements
{
    public abstract void Hide();
    public abstract void Show();

    public GameObject Get_Scene_CanvasObject(GameObject someVar, string name)
    {
        if (someVar != null) return someVar;

        Canvas[] allCanvases = MonoBehaviour.FindObjectsOfType<Canvas>();

        for (int i = 0; i < allCanvases.Length; i++)
        {
            Canvas canvas = allCanvases[i];

            if (canvas.gameObject.name.Contains(name))
                return canvas.gameObject;
        }

        Debug.Log($"'{name}' Canvas object is not set as variable");
        return null;
    }

    public Text Get_Scene_TextField(Text someVar, string name)
    {
        if (someVar != null) return someVar;

        Text[] allTextFields = MonoBehaviour.FindObjectsOfType<Text>();

        for (int i = 0; i < allTextFields.Length; i++)
        {
            Text textField = allTextFields[i];

            if (textField.gameObject.name.Contains(name))
                return textField.GetComponent<Text>();
        }

        Debug.Log($"'{name}' Text component is not set as variable");
        return null;
    }

    public Button Get_Scene_Button(Button someVar, string name)
    {
        if (someVar != null) return someVar;

        Button[] allButtons = MonoBehaviour.FindObjectsOfType<Button>();

        for (int i = 0; i < allButtons.Length; i++)
        {
            Button button = allButtons[i];

            if (button.gameObject.name.Contains(name))
                return button;
        }

        Debug.Log($"'{name}' Button is not set as variable");
        return null;
    }
}
