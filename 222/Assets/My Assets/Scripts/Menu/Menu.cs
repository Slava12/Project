using UnityEngine;

public class Menu : MonoBehaviour
{
    private string _window = "Main Menu";

	void Update()
	{
		audio.volume = Options._audio;
	}

	void OnGUI()
    {
		if (Options.defaultLanguage == 0)
		{
			LanguageManager.LoadLanguageFile(Language.Russian);
		}
	    _window = Options.GetMainMenu(_window);
	    _window = Options.GetOptions(_window);
		_window = Options.GetHelp(_window);
		_window = Options.GetVideo(_window);
	    _window = Options.GetAudio(_window);
	    _window = Options.GetLanguage(_window);
		//var config = LocalizationManager.Instance.LoadResource("Languages");
		//print(config.text);
    }
}
