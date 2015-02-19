/// <summary>
/// Menu.
/// Главное меню игры
/// Создается отдельная сцена а там на любой объект вешается этот скрипт
/// </summary>
using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{

    private int _window = 0;

    // Окна меню
    //private int _window = 100;
    // Звук (пока не работает)
	private float _FloatVolume = OptionsMenu._audio;
    //private int IntVolume;
    // Разрешение экрана
    private float _FloatResolution = 3;
    private int IntResolution;
    // Для вывода значений на экран
    private string StringWidth;
    private string StringHeight;

    //Переменные для расширения экрана
    private int width = 1920;
    private int height = 1080;
    private bool FullScreen = true;
    void OnGUI()
    {

        if (_window == 0)
        {
            GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 180), "Main menu");
            if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 80, 180, 30), "Play"))
            {
                _window = 100;
                Application.LoadLevel(1);
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 40, 180, 30), "Options"))
            {
                _window = 1;
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 0, 180, 30), "Help"))
            {
                _window = 2;
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 40, 180, 30), "Exit game"))
            {
                Application.Quit();
            }
        }

        // Настройки
        if (_window == 1)
        {
            GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 180), "Options");
            if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 80, 180, 30), "Video"))
            {
                _window = 3;
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 40, 180, 30), "Audio"))
            {
                _window = 4;
            }
            //if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 0, 180, 30), "Control"))
            //{ // Управление
            //    _window = 5;
            //}
			if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 40, 180, 30), "Back") || Input.GetKey(KeyCode.Escape))
            {
                _window = 0;
            }
        }
		// Помощь
		if (_window == 2)
		{
			GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 180), "Help");
			GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 80, 180, 140), "Надо добавить больше источников звука и сделать управление ими. Также непонятки с деревьями не радуют. Подумать насчёт Resolution."); // текст 
			if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 40, 180, 30), "Back") || Input.GetKey(KeyCode.Escape))
			{
				_window = 0;
			}
		}
        // Видео
        if (_window == 3)
        {
            GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 180), "Video");
            GUI.Label(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 80, 180, 30), "Resolution:"); // текст 

            _FloatResolution = GUI.HorizontalSlider(new Rect(Screen.width / 2 - 20, Screen.height / 2 - 75, 100, 30), _FloatResolution, 0, 3);
            // Расчеты расширения
            IntResolution = (int)_FloatResolution;
            if (IntResolution == 0)
            {
                width = 640;
                height = 480;
            }
            if (IntResolution == 1)
            {
                width = 1024;
                height = 768;
            }
            if (IntResolution == 2)
            {
                width = 1600;
                height = 900;
            }
            if (IntResolution == 3)
            {
                width = 1920;
                height = 1080;
            }
			StringWidth = width.ToString();
			StringHeight = height.ToString();
            // Вывод на экран выбираемого расширения
            GUI.Label(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 40, 180, 30), StringWidth); // ширина
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 40, 180, 30), StringHeight); // высота

            FullScreen = GUI.Toggle(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 0, 180, 30), FullScreen, "Full screen");
            //if (FullScreen == true) {}

			if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 40, 180, 30), "Save and back"))
            {
                Screen.SetResolution(width, height, FullScreen);//A - ширина. B - высота. С - полноэкранный или оконный.
                _window = 1;
            }
			if (Input.GetKeyUp(KeyCode.Escape))
			{
				_window = 1;
			}
        }
		// Звук
		if (_window == 4)
		{
			GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 180), "Audio");
			GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 80, 180, 140), "Volume:"); // текст 

			_FloatVolume = GUI.HorizontalSlider(new Rect(Screen.width / 2 + 50 - 90, Screen.height / 2 + 6 - 80, 100, 20), _FloatVolume, 0, 1);
			//IntVolume = (int)_FloatVolume;
			//audio.volume = IntVolume;
			audio.volume = _FloatVolume;
			OptionsMenu._audio = audio.volume;
			if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 40, 180, 30), "Back") || Input.GetKeyUp(KeyCode.Escape))
			{
				_window = 1;
			}
		}
    }
	void Update()
	{
		//print("OptionsMenu:");
		//print(OptionsMenu._audio);
		//print("AudioMenu:");
		//print(_FloatVolume);
		audio.volume = OptionsMenu._audio;
	}
}
