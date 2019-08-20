using UnityEngine;
using UnityEngine.Assertions;

public class Eyes : MonoBehaviour
{
    private Animator eyeAnim;

    private void Awake()
    {
        eyeAnim = GetComponent<Animator>();
        Assert.IsNotNull(eyeAnim, "Failed to find Animator component.");
    }

    public void WinkEye()
    {
        eyeAnim.SetTrigger("WinkEye");
    }

    private void Update()
    {
        
    }
}
