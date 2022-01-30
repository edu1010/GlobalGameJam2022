using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[RequireComponent(typeof(ManagerEventRoom))]
public class ObjectDecision : MonoBehaviour, IterfaceInteractable
{

    public GameObject m_fondo;
    bool m_apeal = false;
    float timer = 0f;
    ManagerEventRoom managerEvent;
    // Start is called before the first frame update
    void Start()
    {
        managerEvent = GetComponent<ManagerEventRoom>();


    }

    private void Update()
    {
        if (m_apeal)
        {
            if (Time.time - timer > 0.2f)
            {
                m_apeal = false;
            }
            m_fondo.SetActive(true);
        }
        else
            m_fondo.SetActive(false);

    }
    public void AppealInteractuable()
    {
        m_apeal = true;
        timer = Time.time;
    }

    public void Interact()
    {
        managerEvent.TakeDecision();
        Debug.Log("CambiarEscena");
    }
}
