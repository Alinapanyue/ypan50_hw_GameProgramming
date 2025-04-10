using TMPro;
using UnityEngine;

public class EnemiesUI : MonoBehaviour
{
    private TMP_Text text;

    void Start()
    {
        text = GetComponent<TMP_Text>();
        if (EnemiesManager.instance != null)
        {
            EnemiesManager.instance.onChanged.AddListener(RefreshText);
            RefreshText(); // Initial refresh
        }
        else
        {
            Debug.LogError("EnemiesManager instance not found! Make sure there's an EnemiesManager in the scene.", gameObject);
        }
    }

    void OnEnable()
    {
        // Try to subscribe again when object is enabled
        if (EnemiesManager.instance != null)
        {
            EnemiesManager.instance.onChanged.AddListener(RefreshText);
            RefreshText();
        }
    }

    void OnDisable()
    {
        // Unsubscribe when disabled
        if (EnemiesManager.instance != null)
        {
            EnemiesManager.instance.onChanged.RemoveListener(RefreshText);
        }
    }

    void RefreshText()
    {
        if (text != null && EnemiesManager.instance != null)
        {
            text.text = "Remaining Enemies: " + EnemiesManager.instance.enemies.Count;
        }
    }
}