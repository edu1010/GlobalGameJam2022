using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelController : MonoBehaviour
{
    public Animator m_transition;
    public float m_transitionTime = 1f;


    static LevelController m_LevelLoader = null;


    private void Awake()
    {
        if (m_LevelLoader == null)
        {
            m_LevelLoader = this;
        }
        else
        {
            GameObject.Destroy(this); // ya existe, no hace falta crearla
        }
    }

    static public LevelController GetLoadLevel()
    {
        return m_LevelLoader;
    }
    public void LoadNextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 <= SceneManager.sceneCountInBuildSettings)
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        else
            StartCoroutine(LoadLevel(0));
    }
    public void LoadNextLevel(int nextLevel)
    {
        StartCoroutine(LoadLevel(nextLevel));
    } public void LoadCreditos(int nextLevel,string key)
    {
        StartCoroutine(LoadLevel(nextLevel,key));
    }
    public void LoadNextLevel(string nextLevel)
    {
        int l_nextLevel = SceneManager.GetSceneByName(nextLevel).buildIndex;
        StartCoroutine(LoadLevel(l_nextLevel));
    }

    IEnumerator LoadLevel(int levelIndex)
    {

        m_transition.SetTrigger("Start");
        yield return new WaitForSeconds(m_transitionTime);
        AsyncOperation LoadLevel = SceneManager.LoadSceneAsync(levelIndex);
        LoadLevel.completed += (asyncOperation) =>
        {
            m_transition.SetTrigger("End");
            
            GameController.GetGameController().ResumeGame();
        };
    }
     IEnumerator LoadLevel(int levelIndex,string key)
    {

        m_transition.SetTrigger("Start");
        yield return new WaitForSeconds(m_transitionTime);
        AsyncOperation LoadLevel = SceneManager.LoadSceneAsync(levelIndex);
        LoadLevel.completed += (asyncOperation) =>
        {
            m_transition.SetTrigger("End");
            
            GameController.GetGameController().ResumeGame();
            GameObject.FindGameObjectWithTag("Creditos").GetComponent<LocalizatedText>().Key = key;
        };
    }

}
