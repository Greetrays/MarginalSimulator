using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewAction", menuName = "CrateAction", order = 51)]

public class Action : ScriptableObject
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _lable;
    [SerializeField] private int _requiredLevel;
    [SerializeField] private int _price;
    [SerializeField] private int _health;
    [SerializeField] private int _mana;
    [SerializeField] private int _happines;
    [SerializeField] private int _energy;
    [SerializeField] private int _reward;
    [SerializeField] private ManaConditioins _manaConditions;
    [SerializeField] private HappinesConditioins _happinesConditions;
    [SerializeField] private EnergyCondition _energyConditions;
    [SerializeField] private HealthCondition _healthConditions;

    public ManaConditioins ManaCondition => _manaConditions;
    public HappinesConditioins HappinesCondition => _happinesConditions;
    public EnergyCondition EnergyCondition => _energyConditions;
    public HealthCondition HealthCondition => _healthConditions;

    private Player _player;

    public Sprite Icon => _icon;
    public string Lable => _lable;
    public int RequiresLevel => _requiredLevel;
    public int Price => _price;

    public void Init(Player player)
    {
        _player = player;
    }

    public void OnActionButton()
    {
        if (_manaConditions.StartCheckConditioin(_player.GetComponent<PlayerMana>()) && 
            _energyConditions.StartCheckConditioin(_player.GetComponent<PlayerEnergy>()) &&
            _happinesConditions.StartCheckConditioin(_player.GetComponent<PlayerHappines>())&&
            _healthConditions.StartCheckConditioin(_player.GetComponent<PlayerHealth>()))
        {
            _player.MakeAction(_price, _health, _mana, _happines, _energy, _reward);
        }
    }
}

[System.Serializable]

public class Condition
{
    [SerializeField] private int _minValue;
    [SerializeField] private int _maxValue;
    [SerializeField] private string _lable;
    [SerializeField] private string _description;

    public int MinValue => _minValue;
    public int MaxValue => _maxValue;

    public event UnityAction<string, string> Failed;

    public bool CheckCondition(int currentValue)
    {
        if (currentValue < _minValue || currentValue > _maxValue)
        {
            Failed?.Invoke(_lable, _description);
            return false;
        }

        return true;
    }
}

[System.Serializable]
public class ManaConditioins : Condition
{
    public bool StartCheckConditioin(PlayerMana playerMana)
    {
        return CheckCondition(playerMana.CurrentCount);
    }
}

[System.Serializable]
public class HappinesConditioins : Condition
{
    public bool StartCheckConditioin(PlayerHappines playerHappines)
    {
        return CheckCondition(playerHappines.CurrentCount);
    }
}

[System.Serializable]
public class HealthCondition : Condition
{
    public bool StartCheckConditioin(PlayerHealth playerHealth)
    {
        return CheckCondition(playerHealth.CurrentCount);
    }
}

[System.Serializable]
public class EnergyCondition : Condition
{
    public bool StartCheckConditioin(PlayerEnergy playerHealth)
    {
        return CheckCondition(playerHealth.CurrentCount);
    }
}
