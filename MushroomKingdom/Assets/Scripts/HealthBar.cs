using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthBar : MonoBehaviour
{
    public Image healthBarImage;
    public HeroMushroom heroShroom;

    public void UpdateHealthBar() {
        float duration = 0.75f * (heroShroom.CurrentHealth / heroShroom.MaxHealth);

        healthBarImage.DOFillAmount( heroShroom.CurrentHealth / heroShroom.MaxHealth, duration);

        Color barColor = Color.green;

        if (heroShroom.CurrentHealth < heroShroom.MaxHealth * 0.25f) {
            barColor = Color.red;
        }
        else if(heroShroom.CurrentHealth < heroShroom.MaxHealth * 0.66f) {
            barColor = Color.yellow;
        }

        healthBarImage.DOColor(barColor, duration);
    }
}
