using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Star : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    List<Sprite> mouthSprites = new List<Sprite>();

    private Animator eyeAnim;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Assert.IsNotNull(spriteRenderer, "Failed to find Sprite Renderer component on the Star.");
        eyeAnim = GetComponent<Animator>();
        Assert.IsNotNull(eyeAnim, "Failed to find Animator on the Star's eyes.");
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ChangeFace());
    }

    
    private IEnumerator ChangeFace()
    {
        while (true)
        {
            spriteRenderer.sprite = mouthSprites[0];
            yield return new WaitForSeconds(3f);
            spriteRenderer.sprite = mouthSprites[1];
            eyeAnim.SetTrigger("WinkEye");
            yield return new WaitForSeconds(3f);
        }
    }
}
