using UnityEngine;

public class Final : MonoBehaviour
{
	private string _window = "Show";
	// Use this for initialization
	void Start ()
	{
		if (Options.defaultLanguage == 0)
		{
			LanguageManager.LoadLanguageFile(Language.Russian);
		}
		Screen.showCursor = true;
	}
	
	// Update is called once per frame
	void Update () {
		audio.volume = Options._audio;
	}

	void OnGUI()
	{
		//GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 120, 200, 200), "<size=22><color=black>" + "You are dead" + "</color></size>");
		if (_window == "Show")
		{
			//GUI.Label(new Rect(Screen.width / 2 - 65, Screen.height / 2 - 120, 200, 200), "<size=22><color=white>" + "You are dead" + "</color></size>");
			GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 120, 200, 240), "<size=22>" + LanguageManager.GetText("Dead") + "</size>");
			GUI.Label(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 80, 200, 200), LanguageManager.GetText("DaysPassed") + ": " + GameTime.daysPassed);
			//GUI.Label(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 40, 200, 200), "Press any key to continue");
			if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 80, 180, 30), LanguageManager.GetText("PressToContinue")))
			{
				_window = "Main Menu";
			}
		}
		if (_window == "Main Menu")
		{
			GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 120, 200, 240), "<size=22>" + LanguageManager.GetText("Dead") + "</size>");
			if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 80, 180, 30), "-" + LanguageManager.GetText("LoadGame") + "-"))
			{

			}
			if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 40, 180, 30), LanguageManager.GetText("Options")))
			{
				_window = "Options";
			}
			if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 0, 180, 30), LanguageManager.GetText("Help")))
			{
				_window = "Help";
			}
			if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 40, 180, 30), LanguageManager.GetText("MainMenu")))
			{
				Application.LoadLevel(0);
			}
			if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 80, 180, 30), LanguageManager.GetText("ExitGame")))
			{
				Application.Quit();
			}
		}
		_window = Options.GetOptions(_window);
		_window = Options.GetAudio(_window);
		_window = Options.GetVideo(_window);
		_window = Options.GetLanguage(_window);
		_window = Options.GetHelp(_window);
	}
}
