using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerEventRoom : MonoBehaviour
{
    public EventNextRoomScriptableObject m_Event;
    public void TakeDecision()
    {
        LevelsData.GetLevelsData().IncrementVariable(m_Event.m_VarToChange.ToString(), m_Event.m_Quantity);

        LevelsData.GetLevelsData().IncrementVariable(m_Event.m_VarToChange2.ToString(), m_Event.m_Quantity2);
        LevelsData.GetLevelsData().IncrementVariable(m_Event.m_VarToChange3.ToString(), m_Event.m_Quantity3);

        LevelsData.GetLevelsData().CalculateNextScene(m_Event.m_CurrentEtapa);
    }
}
