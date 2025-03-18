using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    public void HandleQuit()
    {
        Application.Quit();
    }

    public void Begin()
    {
        SceneManager.LoadScene(1);
    }
}
