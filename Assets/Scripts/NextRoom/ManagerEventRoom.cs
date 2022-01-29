using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerEventRoom : MonoBehaviour
{
    EventNextRoomScriptableObject m_Event;
    public void TakeDecision()
    {
        LevelsData.GetLevelsData().IncrementVariable(m_Event.m_VarToChange.ToString(), m_Event.m_Quantity);
        LevelsData.GetLevelsData().CalculateNextScene(m_Event.m_CurrentEtapa);
    }
}
