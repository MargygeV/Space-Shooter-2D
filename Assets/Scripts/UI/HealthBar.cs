using UnityEngine;
using TMPro;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private TMP_Text _textField;

    private void OnEnable()
    {
        Player.HealthChanged += HealthChanger;
    }

    private void OnDisable()
    {
        Player.HealthChanged -= HealthChanger;
    }

    private void HealthChanger(float health)
    {
        _textField.text = "x " + health;
    }
}
