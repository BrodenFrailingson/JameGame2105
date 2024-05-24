using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int MaxHelath = 100;
    public int currentHelath;

    public GameManger GM;

    public HealthBar healthBar;


    // Start is called before the first frame update
    void Start()
    {
        currentHelath = MaxHelath;
        healthBar.SetMaxHelath(MaxHelath);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }

        if (currentHelath <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }

    void TakeDamage(int damage)
    {
        currentHelath -= damage;

        healthBar.SetHealth(currentHelath);
    }
}
