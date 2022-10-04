using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private Slider _slider;
    [SerializeField] private float _speed;

    private Coroutine _changeBar;

    private void OnEnable()
    {
        _playerStats.Changed += OnChange;
    }

    private void OnDisable()
    {
        _playerStats.Changed -= OnChange;
    }

    private void Start()
    {
        _slider.maxValue = _playerStats.MaxCount;
        _slider.value = _playerStats.CurrentCount;
    }

    private void OnChange(int value)
    {
        if (_changeBar != null)
        {
            StopCoroutine(_changeBar);
            _changeBar = StartCoroutine(ChangeBar(value));
        }
        else
        {
            _changeBar = StartCoroutine(ChangeBar(value));
        }
    }

    private IEnumerator ChangeBar(int value)
    {
        while (_slider.value != value)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, value, _speed * Time.deltaTime);
            yield return null;
        }
    }
}
