using UnityEngine; 

public class Pause : MonoBehaviour
{
	// Игровая пауза
	public static bool _paused;
	// Окна меню
	private string _window = "Game";
	//private float _angle = 0f;

    void Start()
    {
        Screen.showCursor = false;
	    _paused = false;
	    Time.timeScale = 1;
    }
	// Update выполняется на каждый кадр 
	void Update ()
	{	
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
			var mouseLook = GameObject.Find("First Person Controller").GetComponent("MouseLook");
			Destroy(mouseLook);
		}
		else
		{
			Time.timeScale = 1;
			_paused = false;
			_window = "Game";
			audio.Play();
			Screen.showCursor = false;
			GameObject.Find("First Person Controller").AddComponent("MouseLook");
		}
	} 
	
	void  OnGUI (){
		//////////////////
		GUI.Box(new Rect(Screen.width - 150, Screen.height - 100, 120, 25), LanguageManager.GetText("Health") + " = " + ((int)PlayerWater.health).ToString());
		GUI.Box(new Rect(Screen.width - 150, Screen.height - 70, 120, 25), LanguageManager.GetText("Oxygen") + " = " + ((int)PlayerWater.oxygen).ToString());
		////////////////////////////
		GUI.Box(new Rect(50, 15, 100, 25), LanguageManager.GetText("Day") + ": " + GameTime.daysPassed);
		GUI.Box(new Rect(50, 50, 100, 25), GameTime.hour + (int)GameTime.timeInHours + " : " + GameTime.minute + GameTime.minutes + " : " + GameTime.second + GameTime.seconds);
		////////////////////////////
		if (_window == "Main Menu")
		{
			GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 120, 200, 200), "<size=22>" + LanguageManager.GetText("Pause") + "</size>");
			if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 80, 180, 30), LanguageManager.GetText("Continue")))
			{
				Time.timeScale = 1;
				_paused = false;
				_window = "Game";
				audio.Play();
				Screen.showCursor = false;
				GameObject.Find("First Person Controller").AddComponent("MouseLook");
			}
			if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 40, 180, 30), LanguageManager.GetText("Options")))
			{
				_window = "Options";
			}
			if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 0, 180, 30), LanguageManager.GetText("MainMenu")))
			{
				Application.LoadLevel(0);
			}
			if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 40, 180, 30), LanguageManager.GetText("ExitGame")))
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