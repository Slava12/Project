using UnityEngine; 

public class Pause : MonoBehaviour
{
	public MouseLook mouseLookX;
	public MouseLook mouseLookY;
	// Игровая пауза
	public static bool _paused;
	// Окна меню
	private string _window = "Game";

    void Start()
    {
		mouseLookX.maximumX = 360;
		mouseLookX.minimumX = -360;
		mouseLookX.sensitivityX = 5;
	    mouseLookY.maximumY = 60;
	    mouseLookY.minimumY = -35;
	    mouseLookY.sensitivityY = 5;
        Screen.showCursor = false;
	    _paused = false;
	    Time.timeScale = 1;
    }
	// Update выполняется на каждый кадр 
	void Update ()
	{
		if (Options.defaultLanguage == 0)
		{
			LanguageManager.LoadLanguageFile(Language.Russian);
		}
		audio.volume = Options._audio;
		// Ставим игру на паузу
		if (!Input.GetKeyUp(KeyCode.Escape)) return;
		if (!_paused)
		{
			Time.timeScale = 0;
			_paused = true;
			_window = "Main Menu";
			audio.Pause();
			Screen.showCursor = true;
			mouseLookX.enabled = false;
			mouseLookY.enabled = false;
		}
		else
		{
			Time.timeScale = 1;
			_paused = false;
			_window = "Game";
			audio.Play();
			Screen.showCursor = false;
			mouseLookX.enabled = true;
			mouseLookY.enabled = true;
		}
	} 
	
	void  OnGUI ()
	{
		//////////////////
		GUI.Box(new Rect(Screen.width - 150, Screen.height - 100, 120, 25), LanguageManager.GetText("Health") + " = " + (int)(Character.health));
		GUI.Box(new Rect(Screen.width - 150, Screen.height - 70, 120, 25), LanguageManager.GetText("Oxygen") + " = " + (int)(Character.oxygen));
		////////////////////////////
		GUI.Box(new Rect(50, 15, 100, 25), LanguageManager.GetText("Day") + ": " + GameTime.daysPassed);
		GUI.Box(new Rect(50, 50, 100, 25), GameTime.hour + (int)GameTime.timeInHours + " : " + GameTime.minute + GameTime.minutes + " : " + GameTime.second + GameTime.seconds);
		////////////////////////////
		if (_window == "Main Menu")
		{
			GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 120, 200, 280), "<size=22>" + LanguageManager.GetText("Pause") + "</size>");
			if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 80, 180, 30), LanguageManager.GetText("Continue")))
			{
				Time.timeScale = 1;
				_paused = false;
				_window = "Game";
				audio.Play();
				Screen.showCursor = false;
				mouseLookX.enabled = true;
				mouseLookY.enabled = true;
			}
			if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 40, 180, 30), "-" + LanguageManager.GetText("SaveGame") + "-"))
			{

			}
			if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 0, 180, 30), "-" + LanguageManager.GetText("LoadGame") + "-"))
			{

			}
			if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 40, 180, 30), LanguageManager.GetText("Options")))
			{
				_window = "Options";
			}
			if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 80, 180, 30), LanguageManager.GetText("MainMenu")))
			{
				Application.LoadLevel(0);
			}
			if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 120, 180, 30), LanguageManager.GetText("ExitGame")))
			{
				Application.Quit();
			}
		}
		_window = Options.GetOptions(_window);
		_window = Options.GetAudio(_window);
		_window = Options.GetVideo(_window);
		_window = Options.GetLanguage(_window);
	}
}