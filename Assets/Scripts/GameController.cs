using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    Player m_Player;
    static GameController m_GameController = null;
    private void Awake()
    {
        if (m_GameController == null)
        {
            m_GameController = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
        else
        {
            GameObject.Destroy(this); // ya existe, no hace falta crearlo
        }
    }
    static public GameController GetGameController()
    {
        return m_GameController;
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        m_Player.m_Pause = true;
        ShoweMouse();
        MenusController.GetMenuController().ShowCanvasPause();
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        m_Player.m_Pause = false;
        HideMouse();
        MenusController.GetMenuController().ShowCanvasHud();

    }
    public void SetPlayer(Player _Player)
    {
        m_Player = _Player;
    }
    public Player GetPlayer()
    {
        return m_Player;
    }

    public void HideMouse()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void ShoweMouse()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
