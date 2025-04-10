using TMPro;
using UnityEngine;

public class WavesUI : MonoBehaviour
{
    private TMP_Text text;

    void Start()
    {
        text = GetComponent<TMP_Text>();
        if (WavesManager.instance != null)
        {
            WavesManager.instance.onChanged.AddListener(RefreshText);
            RefreshText(); // Initial refresh
        }
        else
        {
            Debug.LogError("WavesManager instance not found!", gameObject);
        }
    }

    void OnEnable()
    {
        // Try to subscribe again when object is enabled
        if (WavesManager.instance != null)
        {
            WavesManager.instance.onChanged.AddListener(RefreshText);
            RefreshText();
        }
    }

    void OnDisable()
    {
        // Unsubscribe when disabled
        if (WavesManager.instance != null)
        {
            WavesManager.instance.onChanged.RemoveListener(RefreshText);
        }
    }

    void RefreshText()
    {
        if (text != null && WavesManager.instance != null)
        {
            text.text = "Remaining Waves: " + WavesManager.instance.waves.Count;
        }
    }
}