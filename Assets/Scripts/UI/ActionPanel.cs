using UnityEngine;

[RequireComponent(typeof(Animator))]

public class ActionPanel : MonoBehaviour
{
    [SerializeField] private ClosePanelButton _closeButton;

    private Animator _animator;
    private bool _isOpen;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _isOpen = false;
    }

    public void Open()
    {
        if (_isOpen == false)
        {
            _animator.Play(ActionPanelAnimatorController.State.Open);
            _isOpen = true;
            _closeButton.AddListener(this);
        }
    }

    public void Close()
    { 
        _animator.Play(ActionPanelAnimatorController.State.Close);
        _closeButton.RemoveListener();
        _isOpen = false;
    }

    public void DisableObject()
    {
        _animator.Play(ActionPanelAnimatorController.State.Idle);
        _isOpen = false;
    }
}
