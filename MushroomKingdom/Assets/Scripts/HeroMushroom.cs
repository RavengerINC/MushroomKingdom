using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroMushroom : MonoBehaviour
{
    [SerializeField]
    public float MaxHealth;

    [SerializeField]
    public float CurrentHealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            TakeDamage();
        }
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
}
