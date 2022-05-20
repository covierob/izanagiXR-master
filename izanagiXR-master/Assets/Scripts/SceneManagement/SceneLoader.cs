using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(int sceneNumber)
    {
        SceneManager.LoadSceneAsync(sceneNumber);
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}