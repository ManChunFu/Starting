using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[System.Serializable]
public class GameModeIntEvent : UnityEvent<int>
{

}
public class GameMode : MonoBehaviour
{
    public static GameMode instance;
    public GameObject ballPrefab;
    public int spawnBallForEveryBricksDestroyed = 3;

    //public int winSceneIndex;
    //public int loseSceneIndex;

    private int ballsInPlay;
    private int starsInPlay;

    private LoadSceneManager loadSceneManager;


    public GameModeIntEvent onBallsChanged;
    public GameModeIntEvent onStarsChanged;
    private void Awake()
    {
        if (!instance)
            instance = this;
        else
            Destroy(gameObject);

        loadSceneManager = GameObject.Find("LoadSceneManager").GetComponent<LoadSceneManager>();
        Assert.IsNotNull(loadSceneManager, "Failed to access LoadSceneManager.");
    }

    public void OnBallAdded()
    {
        ballsInPlay++;
        onBallsChanged.Invoke(ballsInPlay);
    }

    public void OnBallRemoved()
    {
        ballsInPlay--;
        onBallsChanged.Invoke(ballsInPlay);
        if (ballsInPlay <= 0)
        {
            //SceneManager.LoadScene(loseSceneIndex);
            loadSceneManager.LoseSceneLoad();
        }
    }

    public void OnStarAdded()
    {
        starsInPlay++;
        onStarsChanged.Invoke(starsInPlay);
    }

    public void OnStarRemoved()
    {
        starsInPlay--;
        onStarsChanged.Invoke(starsInPlay);
        if (starsInPlay <= 0)
        {
            //SceneManager.LoadScene(winSceneIndex);
            loadSceneManager.WinScenseLoad();
        }

    }

}
