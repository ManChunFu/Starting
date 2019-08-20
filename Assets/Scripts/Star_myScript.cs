using UnityEngine;
using UnityEngine.Assertions;

public class Star_myScript : MonoBehaviour
{
    private Mouth mouthScript;
    private SpriteRenderer color;


    private void Awake()
    {


        mouthScript = GameObject.Find("Mouth").GetComponent<Mouth>();
        Assert.IsNotNull(mouthScript, "Failed to access to mouthScript");

        color = GetComponent<SpriteRenderer>();
        Assert.IsNotNull(color, "Failed to find Color component.");
        Color currentColor = color.color;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        mouthScript.StopChangeFace();
    }

    private void Update()
    {

    }
}
