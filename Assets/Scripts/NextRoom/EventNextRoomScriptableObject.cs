
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Rooms", menuName = "ScriptableObjects/EventNextRoom", order = 1)]
public class EventNextRoomScriptableObject : ScriptableObject
{
    public etapas m_CurrentEtapa;
    public DecisionsVars m_VarToChange;
    public int m_Quantity = 1;
   
}
