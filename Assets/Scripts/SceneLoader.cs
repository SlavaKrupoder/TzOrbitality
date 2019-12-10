using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string NameScene;

    public void LoadScenes(string ScenesName)
    {
        SceneManager.LoadScene(ScenesName);
    }

    public void LoadScenesToBtn()
    {
        SceneManager.LoadScene(NameScene);
    }
}