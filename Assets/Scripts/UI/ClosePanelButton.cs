using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class ClosePanelButton : MonoBehaviour
{
    Button _closeButton;
    ActionPanel _listener;

    private void Start()
    {
        _closeButton = GetComponent<Button>();
    }

    public void AddListener(ActionPanel panel)
    {
        if (_listener != null)
        {
            _listener.DisableObject();
            RemoveListener();
        }

        _listener = panel;
        _closeButton.onClick.AddListener(_listener.Close);
    }

    public void RemoveListener()
    {
        if (_listener != null)
        {
            _closeButton.onClick.RemoveListener(_listener.Close);
            _listener = null;
        }
    }
}
