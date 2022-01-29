using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelsData : MonoBehaviour
{
    int otaku = 0;
    int family = 0;
    int friends = 0;
    int partner = 0;//girlfriend boyfriend
    static LevelsData m_LevelData = null;
    int currentSceneIndex = 0;
    public List<string> m_ChildScenes;
    public string[] m_YoungScenes;
    public string[] m_AdultScenes;
    
    private void Awake()
    {
        if (m_LevelData == null)
        {
            m_LevelData = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
        else
        {
            GameObject.Destroy(this); // ya existe, no hace falta crearla
        }
    }
    public void IncrementVariable(string var, int quantity)
    {
        switch (var)
        {
            case ("otaku"):
                otaku += quantity;
                break;
            case ("family"):
                family += quantity;
                break;
            case ("friends"):
                friends += quantity;
                break;
            case ("partner"):
                partner += quantity;
                break;
        }
    }
    static public LevelsData GetLevelsData()
    {
        return m_LevelData;
    }
    public void CalculateNextScene(etapas etapa)
    {
        switch (etapa)
        {
            case (etapas.child):
                break; 
            case (etapas.young):
                break;
            case (etapas.adult):
                break;
        }
    }
    public void Child()
    {
        //3 escenas 1 se repite deberemos ponerla dos veces en el indice de build
        //Quito la escena de la carga y cargo una escena
        m_ChildScenes.Remove(SceneManager.GetActiveScene().ToString());
        if (m_ChildScenes.Count > 0)
        {
            int l_scene = Random.Range(0, m_ChildScenes.Count);
            LevelController.GetLoadLevel().LoadNextLevel(m_ChildScenes[l_scene]);
        }
        else
        {
            CalculateNextScene(etapas.young);
        }
    }
}
public enum DecisionsVars
{
    otaku,
    family ,
    friends,
    partner
}
public enum etapas
{
    child,
    young,
    adult
}