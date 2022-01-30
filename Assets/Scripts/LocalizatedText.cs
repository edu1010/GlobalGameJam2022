using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class LocalizatedText : MonoBehaviour
{
    private TextMeshProUGUI _text;
    public string Key;
    public bool m_Pregunta = false;
    public bool m_Respuesta1 = false;
    public bool m_Respuesta2 = false;
    // Start is called before the first frame update
    private void OnEnable()
    {

        Localizator.OnChangeLanguageDelegate += OnLanguageChanged;
    }

    private void OnDisable()
    {
        Localizator.OnChangeLanguageDelegate  -= OnLanguageChanged;
    }

    private void OnLanguageChanged()
    {
        SetText();
    }

    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        if (m_Pregunta)
        {
            Type type = typeof(SceneNames);
            string[] values = Enum.GetNames(type);
            Key = values[(SceneManager.GetActiveScene().buildIndex)]+"Pregunta";
        }
        if (m_Respuesta1)
        {
            Type type = typeof(SceneNames);
            string[] values = Enum.GetNames(type);
            Key = values[(SceneManager.GetActiveScene().buildIndex)]+ "Respuesta1";
        }
        if (m_Respuesta2)
        {
            Type type = typeof(SceneNames);
            string[] values = Enum.GetNames(type);
            Key = values[(SceneManager.GetActiveScene().buildIndex)]+ "Respuesta2";
        }
        SetText();
    }

    private void SetText()
    {
        _text.text = Localizator.RecieveText(Key);
        //String enviar a funcion que mire si hay caracteres espeical
    }

}
