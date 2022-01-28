using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GraphicsController : MonoBehaviour
{
    Resolution[] m_resolutions;
    public Dropdown m_ResolutionDropDown;
    private void Start()
    {
        m_resolutions = Screen.resolutions;
        m_ResolutionDropDown.ClearOptions();
        List<string> l_options = new List<string>();
        int l_currentResIndex = 0;
        for (int i = 0; i < m_resolutions.Length; i++)
        {
            string l_tmpRes = m_resolutions[i].width + " x " + m_resolutions[i].height;
            l_options.Add(l_tmpRes);
            if( m_resolutions[i].width == Screen.currentResolution.width && m_resolutions[i].height == Screen.currentResolution.height)
            {
                l_currentResIndex = i;
            }
        }
        m_ResolutionDropDown.AddOptions(l_options);
        m_ResolutionDropDown.value = l_currentResIndex;
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetFullScreen(bool screen)
    {
        Screen.fullScreen = screen;
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution l_resolution = m_resolutions[resolutionIndex];
        Screen.SetResolution(l_resolution.width, l_resolution.height,Screen.fullScreen);
    }
}
