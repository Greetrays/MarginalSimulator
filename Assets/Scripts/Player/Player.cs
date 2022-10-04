using UnityEngine;

[RequireComponent(typeof(PlayerEnergy))]
[RequireComponent(typeof(PlayerHappines))]
[RequireComponent(typeof(PlayerHealth))]
[RequireComponent(typeof(PlayerMana))]
[RequireComponent(typeof(PlayerMoney))]

public class Player : MonoBehaviour
{
    [SerializeField] private SaverLoader _saverLoader;

    private PlayerMoney _money;
    private PlayerHealth _health;
    private PlayerMana _mana;
    private PlayerHappines _happines;
    private PlayerEnergy _energy;

    public int Money => _money.CurrentCount;
    public int Health => _health.CurrentCount;
    public int Mana => _mana.CurrentCount;
    public int Happines => _happines.CurrentCount;
    public int Energy => _energy.CurrentCount;

    private void Awake()
    {
        _money = GetComponent<PlayerMoney>();
        _health = GetComponent<PlayerHealth>();
        _mana = GetComponent<PlayerMana>();
        _happines = GetComponent<PlayerHappines>();
        _energy = GetComponent<PlayerEnergy>();
    }

    public void MakeAction(int price, int health, int mana, int happines, int energy, int reward)
    {
        _money.Change(-price);
        _money.Change(reward);
        _health.Change(health);
        _mana.Change(mana);
        _happines.Change(happines);
        _energy.Change(energy);
        _saverLoader.SaveGame();
    }

    public void LoadStats(int money, int health, int mana, int happines, int energy)
    {
        _money.LoadStat(money);
        _health.LoadStat(health);
        _mana.LoadStat(mana);
        _happines.LoadStat(happines);
        _energy.LoadStat(energy);
    }
}
