using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Complete
{
    public class TankUI : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TankHealth _tankHealth;

        [Header("UI")]
        [SerializeField] private Slider m_Slider;                             // The slider to represent how much health the tank currently has.
        [SerializeField] private Image m_FillImage;                           // The image component of the slider.
        [SerializeField] private Color m_FullHealthColor = Color.green;    // The color the health bar will be when on full health.
        [SerializeField] private Color m_ZeroHealthColor = Color.red;      // The color the health bar will be when on no health.

        private float _startingHealth;

        private void Awake()
        {
            _startingHealth = _tankHealth.GetStartingHealth();
            m_Slider.maxValue = _startingHealth;
        }

        private void OnEnable()
        {
            _tankHealth.OnUpdateHealth += SetHealthUI;
        }

        private void OnDisable()
        {
            _tankHealth.OnUpdateHealth -= SetHealthUI;
        }

        private void SetHealthUI(float currentHealth)
        {
            // Set the slider's value appropriately.
            m_Slider.value = currentHealth;

            // Interpolate the color of the bar between the choosen colours based on the current percentage of the starting health.
            m_FillImage.color = Color.Lerp(m_ZeroHealthColor, m_FullHealthColor, currentHealth / _startingHealth);
        }
    }
}