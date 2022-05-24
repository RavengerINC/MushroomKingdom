using UnityEngine;

public class DefeatScreen : MonoBehaviour
{
    public static DefeatScreen Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    [SerializeField] private GameObject m_Panel;

    private void Start()
    {
        m_Panel.SetActive(false);
    }

    public void ShowDefeatScreen()
    {
        m_Panel.SetActive(true);
    }
}