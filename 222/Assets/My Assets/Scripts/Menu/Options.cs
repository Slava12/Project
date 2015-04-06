using UnityEngine;
using System.Collections;

public class Options : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	private static float _audio = (float)0.5;
	// Update is called once per frame
	void Update ()
	{
		audio.volume = _audio;
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
			GUI.Box(new Rect(Screen.width/2 - 100, Screen.height/2 - 100, 200, 180), "Options");
			if (GUI.Button(new Rect(Screen.width/2 - 90, Screen.height/2 - 80, 180, 30), "Video"))
			{
				window = "Video";
			}
			if (GUI.Button(new Rect(Screen.width/2 - 90, Screen.height/2 - 40, 180, 30), "Audio"))
			{
				window = "Audio";
			}
			if (GUI.Button(new Rect(Screen.width/2 - 90, Screen.height/2 + 40, 180, 30), "Back") || Input.GetKey(KeyCode.Escape))
			{
				window = "Main Menu";
			}
		}
		return window;
	}

	public static string GetAudio(string window)
	{
		if (window == "Audio")
		{
			GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 180), "Audio");
			GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 80, 180, 140), "Volume:"); // текст 
			_audio = GUI.HorizontalSlider(new Rect(Screen.width / 2 + 50 - 90, Screen.height / 2 + 6 - 80, 100, 20), _audio, 0, 1);
			if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 40, 180, 30), "Back") || Input.GetKeyUp(KeyCode.Escape))
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
			GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 180), "Video");
			GUI.Label(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 80, 180, 30), "Resolution:"); // текст 

			_floatResolution = GUI.HorizontalSlider(new Rect(Screen.width / 2 - 20, Screen.height / 2 - 75, 100, 30), _floatResolution, 0, 3);
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
			GUI.Label(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 40, 180, 30), _stringWidth); // ширина
			GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 40, 180, 30), _stringHeight); // высота

			_fullScreen = GUI.Toggle(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 0, 180, 30), _fullScreen, "Full screen");
			//if (FullScreen == true) {}

			if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 40, 180, 30), "Save and back"))
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
			GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 180), "Help");
			GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 80, 180, 140), "Менять скорость игры: Num0 - Num9"); // текст 
			if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 40, 180, 30), "Back") || Input.GetKey(KeyCode.Escape))
			{
				window = "Main Menu";
			}
		}
		return window;
	}
}
