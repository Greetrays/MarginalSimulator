using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActionTemplate : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _lable;
    [SerializeField] private TMP_Text _textBatton;
    [SerializeField] private Button _actionButton;

    private Action _action;

    public void Render(Action action)
    {
        _action = action;

        if (_action.Price > 0)
        {
            _textBatton.text = $"{_action.Price}р";
        }
        else
        {
            _textBatton.text = "Сделать";
        }    

        _icon.sprite = _action.Icon;
        _lable.text = _action.Lable;
        _actionButton.onClick.AddListener(_action.OnActionButton);
    }
}
