using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerCreditos : MonoBehaviour
{
    public GameObject m_descativate1;
    public GameObject m_descativate2;
    public float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2)
        {
            m_descativate1.SetActive(false);
            m_descativate2.SetActive(false);
        }
        
    }
}
