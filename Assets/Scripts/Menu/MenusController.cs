using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenusController : MonoBehaviour
{
    public GameObject m_MenuPlay;
    public GameObject m_MenuPause;
    public GameObject m_Hud;
    CanvasGroup m_CanvasPlay;
    CanvasGroup m_CanvasPause;
    CanvasGroup m_CanvasHud;
    public Mood mood;
    public GameObject GameObjectText;
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
            GameObject.Destroy(gameObject); // ya existe, no hace falta crearla
        }
        
    }

    private void Start()
    {
        m_CanvasPlay = m_MenuPlay.GetComponent<CanvasGroup>();
        m_CanvasPause = m_MenuPause.GetComponent<CanvasGroup>();
        m_CanvasHud = m_Hud.GetComponent<CanvasGroup>();
        GameController.GetGameController().InitialPauseGame();
    }
    public void ShowCanvasPlayMenu()
    {
        ShowMenu(m_CanvasPlay);
        HideMenu(m_CanvasPause);
        HideMenu(m_CanvasHud);
    }  public void ShowCanvasHud()
    {
            ShowMenu(m_CanvasHud);
            HideMenu(m_CanvasPause);
            HideMenu(m_CanvasPlay);

        
    }
    public void ShowCanvasPause()
    {
        ShowMenu(m_CanvasPause);
        HideMenu(m_CanvasPlay);
        HideMenu(m_CanvasHud);
    }
    void ShowMenu(CanvasGroup canvasGroup)
    {
        canvasGroup.interactable = true;
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
    }
    void HideMenu(CanvasGroup canvasGroup)
    {
        canvasGroup.interactable = false;
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
    }

    public static MenusController GetMenuController()
    {
        return m_MenusController;
    }
    public void ActivateText()
    {
        GameObjectText.SetActive(true);
    }
    public void DesactivateText()
    {
        GameObjectText.SetActive(false);
    }
}
