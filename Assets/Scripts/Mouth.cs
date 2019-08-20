using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Mouth : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    List<Sprite> mouthSprites = new List<Sprite>();

    private Eyes eyeScript;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Assert.IsNotNull(spriteRenderer, "Failed to find Sprite Renderer component on the Star.");

        eyeScript = GameObject.Find("Eyes").GetComponent<Eyes>();
        Assert.IsNotNull(eyeScript, "Failed to access to Eyes script.");
    }
    void Start()
    {
        StartCoroutine(ChangeMouth());
    }

    public void StopChangeFace()
    {
        StopCoroutine(ChangeMouth());
    }

    private IEnumerator ChangeMouth()
    {
        while (true)
        {
            spriteRenderer.sprite = mouthSprites[0];
            yield return new WaitForSeconds(3f);
            spriteRenderer.sprite = mouthSprites[1];
            eyeScript.WinkEye();
            yield return new WaitForSeconds(3f);
        }
    }
}
