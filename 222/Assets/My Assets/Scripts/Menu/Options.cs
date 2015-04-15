using UnityEngine;
using System.Collections;

public class Options : MonoBehaviour {
	//public static Language defaultLanguage = Language.English;
	// Use this for initialization
	void Start () {
		
	}
	public static float _audio = (float)0.5;
	public static int defaultLanguage = 0;
	// Update is called once per frame
	void Update ()
	{
		//audio.volume = _audio;
	}

	// Разрешение экрана
	private static float _floatResolution = 3;
	private static int _intResolution;
	// Для вывода значений на экран
	private static string _stringWidth;
	private static string _stringHeight;

	//Переменные для расширения экрана
	private static int _width = 1920;
	private static int _height = 1080;
	private static bool _fullScreen = true;

	public static string GetOptions(string window)
	{
		if (window == "Options")
		{
			GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 120, 200, 240), "<size=22>" + LanguageManager.GetText("Options") + "</size>");
			if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 80, 180, 30), "-" + LanguageManager.GetText("Controls") + "-"))
			{
				//window = "Video";
			}
			if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 40, 180, 30), LanguageManager.GetText("Video")))
			{
				window = "Video";
			}
			if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 0, 180, 30), LanguageManager.GetText("Audio")))
			{
				window = "Audio";
			}
			if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 40, 180, 30), LanguageManager.GetText("Language")))
			{
				window = "Language";
			}
			if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 80, 180, 30), LanguageManager.GetText("Back")) || Input.GetKey(KeyCode.Escape))
			{
				window = "Main Menu";
			}
		}
		return window;
	}

	public static string GetLanguage(string window)
	{
		if (window == "Language")
		{
			GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 120, 200, 200), "<size=22>" + LanguageManager.GetText("Language") + "</size>");
			if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 80, 180, 30), LanguageManager.GetText("English")))
			{
				LanguageManager.LoadLanguageFile(Language.English);
				defaultLanguage = 1;
			}
			if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 40, 180, 30), LanguageManager.GetText("Russian")))
			{
				LanguageManager.LoadLanguageFile(Language.Russian);
				defaultLanguage = 1;
			}
			if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 0, 180, 30), LanguageManager.GetText("German")))
			{
				LanguageManager.LoadLanguageFile(Language.German);
				defaultLanguage = 1;
			}
			if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 40, 180, 30), LanguageManager.GetText("Back")) || Input.GetKeyUp(KeyCode.Escape))
			{
				window = "Options";
			}
		}
		return window;
	}

	public static string GetAudio(string window)
	{
		if (window == "Audio")
		{
			GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 120, 200, 200), "<size=22>" + LanguageManager.GetText("Audio") + "</size>");
			GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 80, 180, 140), LanguageManager.GetText("Volume")); // текст 
			_audio = GUI.HorizontalSlider(new Rect(Screen.width / 2 + 60 - 90, Screen.height / 2 + 6 - 80, 100, 20), _audio, 0, 1);
			if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 40, 180, 30), LanguageManager.GetText("Back")) || Input.GetKeyUp(KeyCode.Escape))
			{
				window = "Options";
			}
		}
		return window;
	}

	public static string GetVideo(string window)
	{
		if (window == "Video")
		{
			GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 120, 200, 200), "<size=22>" + LanguageManager.GetText("Video") + "</size>");
			GUI.Label(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 80, 180, 30), LanguageManager.GetText("Resolution")); // текст 

			_floatResolution = GUI.HorizontalSlider(new Rect(Screen.width / 2 - 10, Screen.height / 2 - 75, 100, 30), _floatResolution, 0, 3);
			// Расчеты расширения
			_intResolution = (int)_floatResolution;
			if (_intResolution == 0)
			{
				_width = 640;
				_height = 480;
			}
			if (_intResolution == 1)
			{
				_width = 1024;
				_height = 768;
			}
			if (_intResolution == 2)
			{
				_width = 1600;
				_height = 900;
			}
			if (_intResolution == 3)
			{
				_width = 1920;
				_height = 1080;
			}
			_stringWidth = _width.ToString();
			_stringHeight = _height.ToString();
			// Вывод на экран выбираемого расширения
			GUI.Label(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 40, 180, 30), _stringWidth + " x " + _stringHeight); // ширина
			//GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 40, 180, 30), _stringHeight); // высота

			_fullScreen = GUI.Toggle(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 0, 180, 30), _fullScreen, LanguageManager.GetText("FullScreen"));
			//if (FullScreen == true) {}

			if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 40, 180, 30), LanguageManager.GetText("Submit")))
			{
				Screen.SetResolution(_width, _height, _fullScreen);//A - ширина. B - высота. С - полноэкранный или оконный.
				window = "Options";
			}
			if (Input.GetKeyUp(KeyCode.Escape))
			{
				window = "Options";
			}
		}
		return window;
	}

	public static string GetHelp(string window)
	{
		if (window == "Help")
		{
			GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 120, 200, 200), "<size=22>" + LanguageManager.GetText("Help") + "</size>");
			GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 80, 180, 140), LanguageManager.GetText("HelpText")); // текст 
			if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 40, 180, 30), LanguageManager.GetText("Back")) || Input.GetKey(KeyCode.Escape))
			{
				window = "Main Menu";
			}
		}
		return window;
	}

	public static string GetMainMenu(string window)
	{
		if (window == "Main Menu")
		{
			GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 120, 200, 240), "<size=22>" + LanguageManager.GetText("MainMenu") + "</size>");
			if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 80, 180, 30), LanguageManager.GetText("NewGame")))
			{
				Application.LoadLevel(1);
			}
			if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 40, 180, 30), "-" + LanguageManager.GetText("LoadGame") + "-"))
			{

			}
			if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 0, 180, 30), LanguageManager.GetText("Options")))
			{
				window = "Options";
			}
			if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 40, 180, 30), LanguageManager.GetText("Help")))
			{
				window = "Help";
			}
			if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 80, 180, 30), LanguageManager.GetText("ExitGame")))
			{
				Application.Quit();
			}
		}
		return window;
	}
}
