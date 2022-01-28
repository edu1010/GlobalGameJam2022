using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenusController : MonoBehaviour
{
    public GameObject m_MenuPlay;
    public GameObject m_MenuPause;
    CanvasGroup m_CanvasPlay;
    CanvasGroup m_CanvasPause;
    
    static MenusController m_MenusController = null;
    private void Awake()
    {
        if(m_MenusController == null)
        {
            m_MenusController = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
        else
        {
            GameObject.Destroy(this); // ya existe, no hace falta crearla
        }
        
    }

    private void Start()
    {
        m_CanvasPlay = m_MenuPlay.GetComponent<CanvasGroup>();
        m_CanvasPause = m_MenuPause.GetComponent<CanvasGroup>();
    }
    public void ShowCanvasPlay()
    {
        ShowMenu(m_CanvasPlay);
        HideMenu(m_CanvasPause);
    }
    public void ShowCanvasPause()
    {
        ShowMenu(m_CanvasPause);
        HideMenu(m_CanvasPlay);
    }
    void ShowMenu(CanvasGroup canvasGroup)
    {
        canvasGroup.interactable = true;
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
    }
    void HideMenu(CanvasGroup canvasGroup)
    {
        canvasGroup.interactable = false;
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
    }

    public static MenusController GetMenuController()
    {
        return m_MenusController;
    }
}
