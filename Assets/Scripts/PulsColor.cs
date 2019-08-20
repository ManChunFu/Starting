using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(SpriteRenderer))]
public class PulsColor : MonoBehaviour
{
    public Gradient gradiet;
    public float speedMultiplier = 1f;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Assert.IsNotNull(spriteRenderer, "Failed to find SpriteRenderer component");
    }

    private void Update()
    {
        spriteRenderer.color = gradiet.Evaluate(Mathf.PingPong(Time.time * speedMultiplier, 1f));
    }
}
