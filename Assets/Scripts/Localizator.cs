using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum Language
{
    English = 1,
    Catalan,
    Spanish
}


public class Localizator : MonoBehaviour
{
    public TextAsset csvVariable; //Variable del csv
    private static Localizator loc = null;
    //un singleton para acceder desde cualquier lado
    private Dictionary<string, LanguageData> Dict; //Un dicionario
    private Language currentLanguage;
    public delegate void ChangeLangugaeDelegate();
    public static ChangeLangugaeDelegate OnChangeLanguageDelegate;
    //Delegado para que al cambiar el idoma todos los elementos suscritos cambien de idioma
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        if (loc == null)
        {
            loc = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
        else
            GameObject.Destroy(this);
    }

    public static Localizator GetLocalizator()
    {
        return loc;
    }

    private void ReadText()
    {
        string[] lines = csvVariable.text.Split(new char[] { '\n' });
        for (int i = 0; i < lines.Length; i++)
        {
            SaveLines(lines[i]);
        }
    }

    private void SaveLines(string anotherLine)
    {
        string[] words = anotherLine.Split(new char[] { ';' });
        var langData = new LanguageData(words);
        if(Dict == null)
        {
            Dict = new Dictionary<string, LanguageData>();
        }
        Dict.Add(words[0], langData);
    }

    public static void SetLanguage(Language languageToChange)
    {
        loc.currentLanguage = languageToChange;
        OnChangeLanguageDelegate?.Invoke();
    }

    public string RecieveText(string key)
    {
        return loc.Dict[key].GetText(loc.currentLanguage);
    }

    //Funcion que lea el texto y guarde las variables en el dicionario
    //clave y 2 idiomas
    //Empezamos en uno para saltarnos la primera linea del csv
}

public class LanguageData
{
    private Dictionary<Language, string> languageDictionary;

    public LanguageData(string[] dictionaryLines)
    {
        languageDictionary = new Dictionary<Language, string>();
        for (int i = 1; i < dictionaryLines.Length; i++)
        {
            languageDictionary.Add((Language) i, dictionaryLines[i]);
        }
    }
    public string GetText(Language language)
    {
        return languageDictionary[language];
    }
}
