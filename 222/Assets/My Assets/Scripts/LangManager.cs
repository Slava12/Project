using UnityEngine;

/// <summary>
/// Менеджер локализации.
/// </summary>
public class LocalizationManager
{
	#region Singleton

	private static LocalizationManager instance;
	public static LocalizationManager Instance
	{
		get
		{
			if (instance == null)
				instance = new LocalizationManager();
			return instance;
		}
	}

	#endregion

	/// <summary>
	/// Код языка.
	/// </summary>
	public string LanguageCode { get; private set; }

	/// <summary>
	/// Локализовать имя ресурса.
	/// </summary>
	/// <param name="resourceName">Имя ресурса.</param>
	private string LocalizeResourceName(string resourceName)
	{
		return resourceName + this.LanguageCode;
	}

	/// <summary>
	/// Загрузить ресурс.
	/// </summary>
	/// <param name="resourceName">Имя ресурса.</param>
	public TextAsset LoadResource(string resourceName)
	{
		return Resources.Load(this.LocalizeResourceName(resourceName),
		  typeof(TextAsset)) as TextAsset;
	}

	/// <summary>
	/// Конструктор.
	/// </summary>
	private LocalizationManager()
	{
		if (Application.systemLanguage == SystemLanguage.Russian)
			this.LanguageCode = "Ru";
		else
			this.LanguageCode = "En";
	}
}
