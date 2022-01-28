using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class ChangeLenguageButton : MonoBehaviour
{
    public Dropdown m_Button;
    // Start is called before the first frame update
    void Start()
    {
        Type type = typeof(Language);
        List<string> l_options = new List<string>();
        //int i = 0;
        foreach (string item in Enum.GetNames(type))
        {

            l_options.Add(item);
            if(item == Localizator.GetLocalizator().currentLanguage.ToString())
            {
                //m_Button.value = i;
            }
           // i++;
        }
        m_Button.ClearOptions();
        m_Button.AddOptions(l_options);
        
    }

    public void ButtonLanguage(int lenguageIndex)
    {
        Language value = (Language)lenguageIndex;
        Debug.Log(value);
        Localizator.GetLocalizator().SetLanguage(value);
    }

    
}
