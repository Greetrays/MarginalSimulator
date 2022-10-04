using TMPro;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class ErrorPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _lable;
    [SerializeField] private TMP_Text _description;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void AddListener(Condition condition)
    {
        condition.Failed += OnField;
    }

    private void OnField(string lable, string description)
    {
        _lable.text = lable;
        _description.text = description;
        _animator.Play(ErrorPanleAnimationController.State.Move);
    }
}
