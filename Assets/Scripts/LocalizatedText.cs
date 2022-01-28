using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LocalizatedText : MonoBehaviour
{
    private TextMeshProUGUI _text;
    public string Key;
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
        SetText();
    }

    private void SetText()
    {
        _text.text = Localizator.RecieveText(Key);
    }
}
