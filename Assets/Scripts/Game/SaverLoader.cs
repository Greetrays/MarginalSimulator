using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaverLoader : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private List<PlayerStats> _stats;

    private string _filePath;

    private void OnEnable()
    {
        foreach (var item in _stats)
        {
            item.Died += RestartGame;
        }
    }

    private void Start()
    {
        _filePath = Application.persistentDataPath + "/saveValera.gamesave";
        LoadGame();
    }

    private void OnDisable()
    {
        foreach (var item in _stats)
        {
            item.Died -= RestartGame;
        }
    }

    public void SaveGame()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();

        using (FileStream fileStream = new FileStream(_filePath, FileMode.Create))
        {
            Save save = new Save();
            save.SavePlayer(_player.Money, _player.Health, _player.Mana, _player.Happines, _player.Energy);
            binaryFormatter.Serialize(fileStream, save);
        }
    }

    public void LoadGame()
    {
        if (File.Exists(_filePath) == false)
        {
            return;
        }

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        
        using (FileStream fileStream = new FileStream(_filePath, FileMode.Open))
        {
            Save save = (Save)binaryFormatter.Deserialize(fileStream);
            _player.LoadStats(save.PlayerMoney, save.PlayerMana, save.PlayerHappines, save.PlayerHappines, save.PlayerEnergy);
        }
    }

    private void RestartGame()
    {
        File.Delete(_filePath);
        SceneManager.LoadScene(0);
        _player.MakeAction(0, 100, 100, 100, 100, 0);
    }
}

[System.Serializable]
public class Save
{
    private int _playerMoney;
    private int _playerHealth;
    private int _playerMana;
    private int _playerHappines;
    private int _playerEnergy;

    public int PlayerMoney => _playerMoney;
    public int PlayerHealth => _playerHealth;
    public int PlayerMana => _playerMana;
    public int PlayerHappines => _playerHappines;
    public int PlayerEnergy => _playerEnergy;

    public void SavePlayer(int playerMoney, int playerHealth, int playerMana, int playerHappines, int playerEnergy)
    {
        _playerMoney = playerMoney;
        _playerHealth = playerHealth;
        _playerMana = playerMana;
        _playerHappines = playerHappines;
        _playerEnergy = playerEnergy;
    }
}