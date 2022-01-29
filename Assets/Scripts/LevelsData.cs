using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelsData : MonoBehaviour
{
    int otaku = 0;
    int family = 0;
    int friends = 0;
    bool partner = false;//girlfriend boyfriend Cuando se pone a true?
    bool work = false;//Cuando se pone a true?
    int happines = 0;
    bool armario = false;
    static LevelsData m_LevelData = null;
    int currentSceneIndex = 0;
    public List<SceneNames> m_ChildScenes;
    public List<SceneNames> m_TenegerScenes;
    public List<SceneNames> m_UniversityScenes;
    public List<SceneNames> m_AdultScenes;
    
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
                partner = 1==quantity;
                break;
            case ("happines"):
                happines += quantity;
                break;
        }
    }
    static public LevelsData GetLevelsData()
    {
        return m_LevelData;
    }
    public void CalculateNextScene(etapas etapa)
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        switch (etapa)
        {
            case (etapas.child):
                CalculateSceneChild();
                break; 
            case (etapas.teneger):
                CalculateSceneTenneger();
                break; 
            case (etapas.university):
                CalculateUni();
                break;
            case (etapas.adult):
                break;
        }
    }
    public void CalculateSceneChild()
    {
        
        if (currentSceneIndex < 4)
        {
            LevelController.GetLoadLevel().LoadNextLevel(currentSceneIndex + 1);
        }
        else
        {
            CalculateSceneTenneger();
        }
        
    }
    public void CalculateSceneTenneger()
    {
        switch (currentSceneIndex)
        {
            case ((int)SceneNames.QuienTeGusta):
                LevelController.GetLoadLevel().LoadNextLevel(currentSceneIndex + 1);
                break;
            case ((int)SceneNames.HermanoOAmigos):
                LevelController.GetLoadLevel().LoadNextLevel(currentSceneIndex + 1);
                break;
            case ((int)SceneNames.Declararte):
                LevelController.GetLoadLevel().LoadNextLevel(currentSceneIndex + 1);
                break;
            case ((int)SceneNames.Llamada):
                LevelController.GetLoadLevel().LoadNextLevel(currentSceneIndex + 1);
                break;
            case ((int)SceneNames.Jugar):
                LevelController.GetLoadLevel().LoadNextLevel(currentSceneIndex + 1);
                break;
            case ((int)SceneNames.Comprar):
                LevelController.GetLoadLevel().LoadNextLevel(currentSceneIndex + 1);
                break;
            case ((int)SceneNames.EstudiarOQuedar):
                LevelController.GetLoadLevel().LoadNextLevel(currentSceneIndex + 1);
                break;
             case ((int)SceneNames.ParejaHermanoTeTiraCaņa):
                if (otaku >= 3)
                {
                    LevelController.GetLoadLevel().LoadNextLevel(currentSceneIndex + 1);
                }
                else if (friends >= 3)
                {
                    LevelController.GetLoadLevel().LoadNextLevel((int)SceneNames.GuardarTabaco);
                }
                else
                {
                    LevelController.GetLoadLevel().LoadNextLevel((int)SceneNames.HablarPadres2);
                }
                break;

             case ((int)SceneNames.HablarPadres):
                if (friends >= 3)
                {
                    LevelController.GetLoadLevel().LoadNextLevel((int)SceneNames.GuardarTabaco);
                }
                else
                {
                    LevelController.GetLoadLevel().LoadNextLevel((int)SceneNames.HablarPadres2);
                }
                break;
             case ((int)SceneNames.GuardarTabaco):
                LevelController.GetLoadLevel().LoadNextLevel((int)SceneNames.Dinero);
                break;
             case ((int)SceneNames.Dinero):
                LevelController.GetLoadLevel().LoadNextLevel((int)SceneNames.HablarPadres2);
                break;
             case ((int)SceneNames.HablarPadres2):
                LevelController.GetLoadLevel().LoadNextLevel((int)SceneNames.EstudiarOtrabajar);
                break;
             case ((int)SceneNames.EstudiarOtrabajar):
                LevelController.GetLoadLevel().LoadNextLevel((int)SceneNames.Estudiar);
                break;
              case ((int)SceneNames.Estudiar):
                CalculateUni();
                break;
             

        }
    }
    public void CalculateUni()
    {
        switch (currentSceneIndex)
        {
            case ((int)SceneNames.ComidaElaborada):
                if(partner)
                    LevelController.GetLoadLevel().LoadNextLevel((int)SceneNames.Peli);
                else if(otaku>=3)
                    LevelController.GetLoadLevel().LoadNextLevel((int)SceneNames.IrA);
                else if(friends>=3)
                    LevelController.GetLoadLevel().LoadNextLevel((int)SceneNames.IrA2);
                else
                    LevelController.GetLoadLevel().LoadNextLevel((int)SceneNames.Llamada);
                break;
            case ((int)SceneNames.Peli):
                if (otaku >= 3)
                    LevelController.GetLoadLevel().LoadNextLevel((int)SceneNames.IrA);
                else if (friends >= 3)
                    LevelController.GetLoadLevel().LoadNextLevel((int)SceneNames.IrA2);
                else
                    LevelController.GetLoadLevel().LoadNextLevel((int)SceneNames.NoviaOamigo);
                break;
            case ((int)SceneNames.IrA):
                if (friends >= 3)
                    LevelController.GetLoadLevel().LoadNextLevel((int)SceneNames.IrA2);
                else if (partner)
                    LevelController.GetLoadLevel().LoadNextLevel((int)SceneNames.NoviaOamigo);
                else
                    LevelController.GetLoadLevel().LoadNextLevel((int)SceneNames.Llamada);
                break;
            case ((int)SceneNames.NoviaOamigo):
                LevelController.GetLoadLevel().LoadNextLevel((int)SceneNames.Llamada);
                break;
            case ((int)SceneNames.Llamada):
                if (friends >= 3)
                {
                    LevelController.GetLoadLevel().LoadNextLevel((int)SceneNames.RobarAlsuper);
                }else if (otaku >= 3)
                {
                    LevelController.GetLoadLevel().LoadNextLevel((int)SceneNames.Comprar2);
                }
                else if(work)
                {
                    LevelController.GetLoadLevel().LoadNextLevel((int)SceneNames.QuedadaTrabajo);
                }
                else
                {
                    LevelController.GetLoadLevel().LoadNextLevel((int)SceneNames.PedirDinero);
                }
                           break;
            case ((int)SceneNames.RobarAlsuper):

                           break;
            case ((int)SceneNames.Comprar2):
                           break;
            case ((int)SceneNames.JugarCon):
                           break;
            case ((int)SceneNames.QuedadaTrabajo):
                           break;
            case ((int)SceneNames.Dinero2):
                           break;
            case ((int)SceneNames.PedirDinero):
                           break;

        }

    }
}
public enum DecisionsVars
{
    otaku ,
    family ,
    friends,
    partner,
    happines
}
public enum etapas
{
    child,
    teneger,
    university,
    adult
}

public enum SceneNames
{
    ObjetosNuevo=0,
    CalleOCasa,
    Hermano,
    CalleOCasa2,
    QuienTeGusta,//ADOLESCENTE
    HermanoOAmigos,
    Declararte,
    Llamada,
    Jugar,
    Comprar,
    EstudiarOQuedar,
    ParejaHermanoTeTiraCaņa,
    HablarPadres,
    GuardarTabaco, 
    Dinero,
    HablarPadres2,
    EstudiarOtrabajar,
    Estudiar,
    ComidaElaborada,//uni
    Peli,
    IrA,
    IrA2,
    NoviaOamigo,
    ContestarLlamada,
    RobarAlsuper,
    Comprar2,
    JugarCon,
    QuedadaTrabajo,
    Dinero2,
    PedirDinero,
    HacerFavor,
    InvertirCripto,
    QuedarAmiga,
    IrA3,
    TenerHijos,
    TrabjarTraficante,//Opcional
    CelebrarCumplePareja,
    IrATrabajar,
    Vacaciones,
    CambiarCasa,
    TrabajarMas

}