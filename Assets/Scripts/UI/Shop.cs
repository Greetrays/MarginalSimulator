using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private List<Action> _actions;
    [SerializeField] private Player _player;
    [SerializeField] private ActionTemplate _actionTemplate;
    [SerializeField] private ErrorPanel _errorPanel;

    private void Awake()
    {
        foreach (var item in _actions)
        {
            Render(item);
            _errorPanel.AddListener(item.HappinesCondition);
            _errorPanel.AddListener(item.ManaCondition);
            _errorPanel.AddListener(item.HealthCondition);
            _errorPanel.AddListener(item.EnergyCondition);
        }
    }

    private void Render(Action action)
    {
        var item = Instantiate(_actionTemplate, _container);
        item.Render(action);
        action.Init(_player);
    }
}
