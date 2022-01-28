using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
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

}
