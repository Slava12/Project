using UnityEngine;
using System.Collections;

public class Options : MonoBehaviour {
	//public static Language defaultLanguage = Language.English;
	// Use this for initialization
	void Start ()
	{
	}

	private static bool _showResolutions;
	private static bool _showQualities;
	private static string _qualityName = "null";
	private static int _qualityNumber = 5;        //количество режимов качества изображения
	public static float _audio = (float)0.5;
	public static int defaultLanguage;
	// Update is called once per frame
	void Update ()
	{
		//audio.volume = _audio;
	}

	// Для вывода значений на экран
	private static string _stringWidth = "1920";
	private static string _stringHeight = "1080";

	//Переменные для расширения экрана
	private static int _width = 1920;
	private static int _height = 1080;
	private static int _temporaryWidth = 1920;
	private static int _temporaryHeight = 1080;
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
			if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 0, 180, 30), "-" + LanguageManager.GetText("German") + "-"))
			{
				//LanguageManager.LoadLanguageFile(Language.German);
				//defaultLanguage = 1;
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
		if (Input.anyKey &&
			(Input.mousePosition.x < Screen.width / 2 + 100 || Input.mousePosition.x > Screen.width / 2 + 210 ||               // ширина, как и в кнопках, а высота (из-за разных знаков) - у верхней границы
			Input.mousePosition.y < Screen.height / 2 - 140 || Input.mousePosition.y > Screen.height / 2 + 40))                // минус меняется на плюс, а нижняя на минус: (offset*количество кнопок - верхняя граница)
		{
			_showQualities = false;
		}
		if (Input.anyKey &&
			(Input.mousePosition.x < Screen.width / 2 + 100 || Input.mousePosition.x > Screen.width / 2 + 200 ||
			Input.mousePosition.y < Screen.height / 2 - 100 || Input.mousePosition.y > Screen.height / 2 + 80))
		{
			_showResolutions = false;
		}
		if (window == "Video")
		{
			int[,] resolutionList = { { 1920, 1600, 1366, 1024, 1280, 640 }, { 1080, 900, 768, 768, 720, 480 } };
			GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 120, 200, 200), "<size=22>" + LanguageManager.GetText("Video") + "</size>");
			GUI.Label(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 75, 180, 30), LanguageManager.GetText("Resolution")); // текст 
			if (GUI.Button(new Rect(Screen.width / 2 - 10, Screen.height / 2 - 80, 100, 30), _stringWidth + " x " + _stringHeight))
			{
				_showResolutions = true;
				_showQualities = false;
			}
			if (_showResolutions)
			{
				var offsetHeight = 0;
				for (var resolutionNumber = 0; resolutionNumber < resolutionList.Length / 2; resolutionNumber++)
				{
					if (GUI.Button(new Rect(Screen.width / 2 + 100, Screen.height / 2 - 80 + offsetHeight, 100, 30), resolutionList[0, resolutionNumber] + " x " + resolutionList[1, resolutionNumber]))
					{
						_temporaryWidth = resolutionList[0, resolutionNumber];
						_temporaryHeight = resolutionList[1, resolutionNumber];
						_showResolutions = false;
					}
					offsetHeight += 30;
				}
				_stringWidth = _temporaryWidth.ToString();
				_stringHeight = _temporaryHeight.ToString();
				
			}
			string[] qualityList = { LanguageManager.GetText("Minimum"),
									 LanguageManager.GetText("Low"),
									 LanguageManager.GetText("Medium"),
									 LanguageManager.GetText("High"),
									 LanguageManager.GetText("VeryHigh"),
									 LanguageManager.GetText("TheBest") };
			if (_qualityName == "null")
			{
				_qualityName = qualityList[qualityList.Length - 1];
			}
			_qualityName = qualityList[_qualityNumber];
			GUI.Label(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 35, 180, 30), LanguageManager.GetText("Quality"));
			if (GUI.Button(new Rect(Screen.width / 2 - 20, Screen.height / 2 - 40, 110, 30), _qualityName))
			{
				_showResolutions = false;
				_showQualities = true;

			}
			if (_showQualities)
			{
				var offsetHeight = 0;
				for (var qualityNumber = 0; qualityNumber < qualityList.Length; qualityNumber++)
				{
					if (GUI.Button(new Rect(Screen.width / 2 + 100, Screen.height / 2 - 40 + offsetHeight, 110, 30), qualityList[qualityNumber]))
					{
						QualitySettings.SetQualityLevel(qualityNumber, true);
						_qualityName = qualityList[qualityNumber];
						_qualityNumber = qualityNumber;
						_showQualities = false;
					}
					offsetHeight += 30;
				}
			}
			_fullScreen = GUI.Toggle(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 0, 100, 30), _fullScreen, LanguageManager.GetText("FullScreen"));

			if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 40, 90, 30), LanguageManager.GetText("Submit")))
			{
				_width = _temporaryWidth;
				_height = _temporaryHeight;
				Screen.SetResolution(_width, _height, _fullScreen);//A - ширина. B - высота. С - полноэкранный или оконный.
				_showResolutions = false;
				_showQualities = false;
				window = "Options";
			}
			if (GUI.Button(new Rect(Screen.width / 2 - 0, Screen.height / 2 + 40, 90, 30), LanguageManager.GetText("Back")) || Input.GetKeyUp(KeyCode.Escape))
			{
				_stringWidth = _width.ToString();
				_stringHeight = _height.ToString();
				_temporaryWidth = _width;
				_temporaryHeight = _height;
				_showResolutions = false;
				_showQualities = false;
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
