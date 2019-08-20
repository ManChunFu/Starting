using UnityEngine;
using UnityEngine.Assertions;
using System.Collections.Generic;

[RequireComponent(typeof(CircleCollider2D))]
public class Star : MonoBehaviour
{
    [SerializeField] private Sprite normalMouth = null;
    [SerializeField] private Sprite worriedMouth = null;
    public LayerMask reactToLayer;

    private CircleCollider2D awarness;
    private SpriteRenderer mouth;
    private LookAtTarget leftEye;
    private LookAtTarget rightEye;

    private List<GameObject> activScaryObjects = new List<GameObject>();

    private void Awake()
    {
        awarness = GetComponent<CircleCollider2D>();
        Assert.IsNotNull(awarness, "Failed to find CircleCollider2D");

        Transform go = transform.Find("Eyes/LeftEye/Pupil");
        Assert.IsNotNull(go, "Faiiled to locate child \"Eyes/LeftEye/Pupil\".");

        leftEye = go.GetComponent<LookAtTarget>();
        Assert.IsNotNull(leftEye, "Faiiled to locate Look at mouse component.");

        go = transform.Find("Eyes/RightEye/Pupil");
        Assert.IsNotNull(go, "Faiiled to locate child \"Eyes/RightEye/Pupil\".");

        rightEye = go.GetComponent<LookAtTarget>();
        Assert.IsNotNull(rightEye, "Faiiled to locate Look at mouse component.");

        go = transform.Find("Mouth");
        Assert.IsNotNull(go, "Faiiled to locate child \"Mouth\".");

        mouth = go.GetComponent<SpriteRenderer>();
        Assert.IsNotNull(mouth, "Faiiled to SpriteRenderer component on mouth.");


    }

    private void Start()
    {
        GameMode.instance.OnStarAdded();
    }

    private void OnDestroy()
    {
        GameMode.instance.OnStarRemoved();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        activScaryObjects.Add(collision.gameObject);
        UpdateTarget();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        activScaryObjects.Remove(collision.gameObject);
        UpdateTarget();
    }

    private void UpdateTarget()
    {
        if (activScaryObjects.Count > 0)
        {
            Transform target = transform.GetClosestObject(ref activScaryObjects);
            SetWorried(target);
        }
        else
        {
            SetCool();
        }
    }

    public void SetWorried(Transform target)
    {
        mouth.sprite = worriedMouth;
        leftEye.target = target;
        rightEye.target = target;
    }

    public void SetCool()
    {
        mouth.sprite = normalMouth;
        leftEye.target = null;
        rightEye.target = null;
        rightEye.transform.localPosition = Vector3.zero;
    }
}
