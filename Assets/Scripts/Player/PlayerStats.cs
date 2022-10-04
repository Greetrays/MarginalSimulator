using UnityEngine;
using UnityEngine.Events;

public abstract class PlayerStats : MonoBehaviour
{
    [SerializeField] private int _maxCount;
    [SerializeField] private int _currentCount;
    [SerializeField] private int _diedCount;

    public event UnityAction<int> Changed;
    public event UnityAction Died;

    public int MaxCount => _maxCount;
    public int CurrentCount => _currentCount;

    private void Awake()
    {
        if (_currentCount == 0)
        {
            _currentCount = _maxCount;
        }
    }

    public void Change(int value)
    {
        _currentCount += value;
        
        if (_currentCount < 3)
        {
            _diedCount++;
            Debug.Log(_diedCount);
        }
        else
        {
            _diedCount = 0;
        }

        if (_diedCount == 3)
        {
            Died?.Invoke();
        }

        _currentCount = Mathf.Clamp(_currentCount, 0, _maxCount);
        Changed?.Invoke(_currentCount);
    }

    public void LoadStat(int stateCount)
    {
        if (stateCount > _maxCount && stateCount <= 0)
        {
            stateCount = _maxCount;
            _currentCount = stateCount;
        }
        else
        {
            _currentCount = stateCount;
        }
    }
}
