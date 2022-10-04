using TMPro;
using UnityEngine;

public class MoneyPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _money;
    [SerializeField] private PlayerMoney _playerMoney;

    private void OnEnable()
    {
        _playerMoney.Changed += OnChanged;
    }

    private void Start()
    {
        _money.text = _playerMoney.CurrentCount.ToString();
    }

    private void OnDisable()
    {
        _playerMoney.Changed += OnChanged;
    }

    private void OnChanged(int value)
    {
        _money.text = value.ToString();
    }
}
