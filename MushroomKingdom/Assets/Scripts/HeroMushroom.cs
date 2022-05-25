using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroMushroom : MonoBehaviour
{
    [SerializeField]
    public float MaxHealth;

    public float CurrentHealth;

    [SerializeField]
    public float MaxEnergy;

    public float CurrentEnergy;

    public HealthBar healthBar;
    public EnergyBar energyBar;

    // Start is called before the first frame update
    void Awake()
    {
        CurrentHealth = MaxHealth;
        CurrentEnergy = MaxEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        var dt = Time.deltaTime;
        CurrentEnergy = Mathf.Clamp(CurrentEnergy + (5.0f * dt), 0, MaxEnergy);
        energyBar.UpdateEnergyBar();
    }

    public void TakeDamage() {

        CurrentHealth -= MaxHealth / 10f;
        Mathf.Clamp(CurrentHealth, 0, MaxHealth);
        healthBar.UpdateHealthBar();

        if (CurrentHealth <= 0)
            Defeat();
    }

    private void Defeat()
    {
        StartCoroutine(DefeatSequence());
    }

    private IEnumerator DefeatSequence()
    {
        DefeatScreen.Instance.ShowDefeatScreen();

        yield return new WaitForSeconds(3.0f);

        SceneManager.LoadScene("MainMenu");
    }

    public void ShroomSpawned() {
        CurrentEnergy = Mathf.Clamp(CurrentEnergy - 5.0f, 0f, MaxEnergy);
        energyBar.UpdateEnergyBar();
    }
}
