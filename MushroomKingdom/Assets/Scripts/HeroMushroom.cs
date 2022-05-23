using UnityEngine;

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

        healthBar.UpdateHealthBar();
    }
}
