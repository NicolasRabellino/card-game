using NUnit.Framework;
using System.Dynamic;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnemyManager : MonoBehaviour
{
    EnemyType type;
    int stage;
    int exponential;
    public List<GameObject> enemyPrefabs;
    public List<Enemy> enemies;
    
    int enemyCount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyCount = 0;
        stage = GameManager.inst.currentStage;
//         Create(EnemyType.INQUISITOR);
//         Create(EnemyType.THIEF);
//         Create(EnemyType.FERRING);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Create(EnemyType type)
    {
        int health = 0;
        int armor = 0;
        int speed = 0;
        int damage = 0;
        float stance = 0;
        GameObject eObj = Instantiate(enemyPrefabs[enemyCount]);
        Enemy e = eObj.GetComponent<Enemy>();
        switch (type)
        {
            case EnemyType.INQUISITOR:
                health = Random.Range(128 * (stage / 2), 256 * (stage / 2));
                armor = 100; // ROPA?
                damage = Random.Range(10 * (stage / 2), 20 * (stage / 2) ); // adaptar un chingo?
                break;
            case EnemyType.THIEF:
                health = Random.Range(64 * (stage / 2), 128 * (stage / 2));
                armor = 20; // ROPA
                damage = Random.Range(10 * (stage / 2), 20 * (stage / 2));
                break;
            case EnemyType.NOBLE:
                health = Random.Range(64 * (stage / 2), 128 * (stage / 2));
                armor = 20;
                damage = Random.Range(10 * (stage / 2), 20 * (stage / 2));
                break;
                case EnemyType.OBLIGATOR:
                health = Random.Range(64 * (stage / 2), 128 * (stage / 2));
                armor = 20;
                damage = Random.Range(10 * (stage / 2), 20 * (stage / 2));
                break;
            case EnemyType.METALBORN:
                health = Random.Range(64 * (stage / 2), 128 * (stage / 2));
                armor = 20;
                damage = Random.Range(10 * (stage / 2), 20 * (stage / 2));
                break;
            case EnemyType.FERRING:
                health = Random.Range(64 * (stage / 2), 128 * (stage / 2));
                armor = 20;
                damage = Random.Range(10 * (stage / 2), 20 * (stage / 2));
                break;
            case EnemyType.MISTBORN:
                health = Random.Range(64 * (stage / 2), 128 * (stage / 2));
                armor = 20;
                damage = Random.Range(10 * (stage / 2), 20 * (stage / 2));
                break;
            case EnemyType.FULL_FERUCHEMIST:
                health = Random.Range(64 * (stage / 2), 128 * (stage / 2));
                armor = 20;
                damage = Random.Range(10 * (stage / 2), 20 * (stage / 2));
                break;
            case EnemyType.FULLBORN:
                health = Random.Range(64 * (stage / 2), 128 * (stage / 2));
                armor = 20;
                damage = Random.Range(10 * (stage / 2), 20 * (stage / 2));
                break;
            case EnemyType.RUIN_INQUISITOR:
                health = Random.Range(64 * (stage / 2), 128 * (stage / 2));
                armor = 20;
                damage = Random.Range(10 * (stage / 2), 20 * (stage / 2));
                break;
            case EnemyType.WORLDHOPPER:
                health = Random.Range(64 * (stage / 2), 128 * (stage / 2));
                armor = 20;
                damage = Random.Range(10 * (stage / 2), 20 * (stage / 2));
                break;
            case EnemyType.GOD:
                health = Random.Range(64 * (stage / 2), 128 * (stage / 2));
                armor = 20;
                damage = Random.Range(10 * (stage / 2), 20 * (stage / 2));
                break;
        }

        e.SetEnemyStats(health, armor, speed, damage, stance);
        enemyCount++;
        enemies.Add(e);
    }

    public void _DEBUG_GetStats()
    {
        for(int i = 0; i < enemyCount; i++)
        {
            Debug.Log($"Enemy: {i}. MaxHealth: {enemies[i].GetHealth()}. Damage: {enemies[i].GetHealth()}");
        }
    }

    public void OnStageChange()
    {
        stage = GameManager.inst.currentStage;
    }
}
