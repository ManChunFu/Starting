using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Camera _playerCamera;

    private void Awake()
    {
        _playerCamera = Camera.main; //Camera.main uses find objects of tag internally, super rude.
    }



}
