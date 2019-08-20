using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{
    public void OnClick(int scenceToLoad)
    {
        SceneManager.LoadScene(scenceToLoad);
    }
}
