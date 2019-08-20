using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{

    public void LoseSceneLoad()
    {
        SceneManager.LoadScene(1);
    }

    public void WinScenseLoad()
    {
        SceneManager.LoadScene(2);
    }
}
