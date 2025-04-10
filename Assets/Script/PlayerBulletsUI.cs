using TMPro;
using UnityEngine;

public class PlayerBulletsUI : MonoBehaviour
{
    private TMP_Text text;
    public PlayerShooting targetShooting;  // Reference to PlayerShooting component

    void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    void Update()
    {
        text.text = "Bullets: " + targetShooting.bulletsAmount;
    }
}