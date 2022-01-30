using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectReaction : MonoBehaviour, IterfaceInteractable
{
    private Material _mat;
    Color m_originalColor;
    bool m_apeal = false;
    float timer=0f;
    float timerColor=0f;
    // Start is called before the first frame update
    void Start()
    {
        Renderer nRend = GetComponent<Renderer>();
        _mat = nRend.material;
        m_originalColor = _mat.GetColor("_BaseColor");
    }

    
    private void Update()
    {
        if(m_apeal)
        {
            if (Time.time - timer > 0.5f)
            {
                m_apeal = false;
            }
            timerColor += Time.deltaTime;
            if (timerColor > 1.25f)
            {
                ChangeColor(Color.red);
                if (timerColor > 1.25*2f)
                {
                    ChangeColor(m_originalColor);
                    timerColor = 0;
                }
            }
        }
        else
            ChangeColor(m_originalColor);
        
    }
    public void AppealInteractuable()
    {
        m_apeal = true;
        timer = Time.time;


    }

    public void Interact()
    {
        ChangeColor(m_originalColor);
        GameController.GetGameController().GetPlayer().StartObservingObject(gameObject);
    }
    public void ChangeColor(Color color)
    {
        Color nNew = Color.black;//do whatever you want here
        _mat.SetColor("_BaseColor", color);
    }
    
}
