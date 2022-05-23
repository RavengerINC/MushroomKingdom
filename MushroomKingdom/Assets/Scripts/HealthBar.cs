using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBarImage;
    public HeroMushroom heroShroom;

    public void UpdateHealthBar() {
        healthBarImage.fillAmount = Mathf.Clamp(heroShroom.CurrentHealth / heroShroom.MaxHealth, 0, 1f);
    }
}
