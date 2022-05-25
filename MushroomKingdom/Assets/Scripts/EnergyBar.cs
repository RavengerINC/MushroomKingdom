using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EnergyBar : MonoBehaviour
{
    public Image healthBarImage;
    public HeroMushroom heroShroom;

    public void UpdateEnergyBar() {
        float duration = 0.75f * (heroShroom.CurrentEnergy / heroShroom.MaxEnergy);

        healthBarImage.DOFillAmount( heroShroom.CurrentEnergy / heroShroom.MaxEnergy, duration);

        Color barColor = Color.blue;

        if (heroShroom.CurrentEnergy < heroShroom.CurrentEnergy * 0.25f) {
            barColor = Color.grey;
        }
        else if(heroShroom.CurrentEnergy < heroShroom.MaxEnergy * 0.66f) {
            barColor = Color.cyan;
        }

        healthBarImage.DOColor(barColor, duration);
    }
}
