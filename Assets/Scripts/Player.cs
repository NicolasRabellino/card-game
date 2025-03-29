using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public enum States
{
    WIND_WHISPER,
    BUSSINESS_MAN,
    STEALTH
    //meolvide
}

public class Player : MonoBehaviour
{
    public static Player ply;
    public Text elcojon;
    private void Start()
    {
        ply = this;
    }

    float maxHealth;
    float currentHealth;
    int shield;
    int armor;
    int speed;
    int critChance;

    float metalProficiency; // TODO: implement

    private void Update()
    {
        elcojon.text = $"{currentHealth}";
    }
    public void SetPlayerStats(int mh, int a, int s, int cc)
    {
        maxHealth = mh;
        currentHealth = maxHealth;
        armor = a;
        speed = s;
        critChance = cc;
    }
    public void TakeDamage(int damage) // -> 30dmg
    {
        if(shield > 0)
        {
            shield -= damage; // 15 - 30
            if(shield < 0)
            {
                currentHealth += shield; // 100 + (-15) -> 85
            }
        }
        else
        {
            currentHealth -= damage;
            if (currentHealth < 0)
                Die();
        }
    }

    public void ApplyState(States state)
    {
        //TODO: implement
    }

    public void Heal(float heal)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += heal;
            if (currentHealth > maxHealth) currentHealth = maxHealth;
        }
    }

    public void HealPercentage(float heal, bool isMaxPercentage)
    {
        float healing = 0;
        //maxHealth -> curo vida maxima o solo vida faltante?
        //heal -> porcentaje
        if (isMaxPercentage)
        {
            healing = (int)(maxHealth * heal);
            Heal(healing);
            
        }
        else if(!isMaxPercentage)
        {
            float missingHealth = -(currentHealth / maxHealth) + 1; // porcentaje vida faltante. si tenes 75% de vida, te falta 25%
            float missingHealthValue = missingHealth * maxHealth; // VIDA en NUMERO que nos falta
            healing = missingHealthValue * heal;
            Heal(healing);
        }
    }

    public void IncreaseShield(int increase)
    {
        shield += increase;
    }

    public void IncreaseCritChance(int increase)
    {
        if(critChance < 100)
        {
            critChance += increase;
            if (critChance > 100) critChance = 100; // clamp
        }
    }

    void Die()
    {
        //TODO: implement
    }

}
