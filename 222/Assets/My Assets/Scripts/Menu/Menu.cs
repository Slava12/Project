using UnityEngine;

public class Menu : MonoBehaviour
{
    private string _window = "Main Menu";

    void OnGUI()
    {
		if (_window == "Main Menu")
		{
			GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 180), "Main menu");
			if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 80, 180, 30), "Play"))
			{
				Application.LoadLevel(1);
			}
			if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 40, 180, 30), "Options"))
			{
				_window = "Options";
			}
			if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 0, 180, 30), "Help"))
			{
				_window = "Help";
			}
			if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 40, 180, 30), "Exit game"))
			{
				Application.Quit();
			}
		}
	    _window = Options.GetOptions(_window);
		_window = Options.GetHelp(_window);
		_window = Options.GetVideo(_window);
	    _window = Options.GetAudio(_window);
    }
}
