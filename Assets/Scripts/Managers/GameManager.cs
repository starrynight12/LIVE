using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PlayerData CurrentPlayerData;

    public OptionData Options;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            Options = SaveSystem.LoadOptions(); // Attempt to get our option preferences
            
            updateOptions();

            DontDestroyOnLoad(gameObject);
        }
        else 
        {
        Destroy(gameObject);
        }
    }

    public void updateOptions() // Commits any changes made
    {
        if (Options.language != LocalizationManager.Instance.menuLanguage)
        {
            LocalizationManager.Instance.LoadLocalizedMenuText(Options.language); // Load LocalizationManager to fill dictionary

            foreach (var localizedText in Resources.FindObjectsOfTypeAll(typeof(LocalizedText)) as LocalizedText[])
            {
                localizedText.UpdateText();
            }
            SaveSystem.SaveOptions(Options);
        }
    }

}
