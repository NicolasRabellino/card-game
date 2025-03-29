using UnityEditor.SceneManagement;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    EnemyManager manager;
    int maxHealth;
    int currentHealth;
    int armor;
    int speed;
    int damage;
    float stance; // Percentage? -> 2.0f = 200% Stance
    float currentStance;  // Con 0% stance -> vida = 0?
    int stage;

    private void Start()
    {
        manager = GameObject.Find("GeneralManagers").GetComponent<EnemyManager>();
    }

    public void SetEnemySprite(EnemyType type)
    {
        Sprite[] loadedSprites = Resources.LoadAll<Sprite>("Sprites/Enemy");
        foreach (Sprite sprite in loadedSprites)
        {
            if (sprite.name == $"{type}")
            {
                GetComponent<SpriteRenderer>().sprite = sprite;
                break;
            }
        }
    }

    public void SetEnemyStats(int mh, int arm, int spd, int dmg, float stnc)
    {
        maxHealth = mh;
        currentHealth = maxHealth;
        armor = arm;
        speed = spd;
        damage = dmg;
        stance = stnc;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }  

    public void TakeStanceDamage(float damage) // no queda asi ni a palos
    {
        currentStance -= damage;
        if (currentStance <= 0)
        {
            Die();
        }
    }

    public void Heal(int heal)
    {
        currentHealth += heal;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public int GetHealth()
    {
        return maxHealth;
    }

    public int GetArmor()
    {
        return armor;
    }
    public int GetSpeed()
    {
        return speed;
    }

    public float GetStance()
    {
        return stance;
    }

    public int GetDamage()
    {
        return damage;
    }

    void Die()
    {

    }

}
