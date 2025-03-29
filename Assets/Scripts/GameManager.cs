using UnityEditor.SceneManagement;
using UnityEngine;

public enum GameState
{
    PLAYING,
    STORE,
    EVENT,
    SELECTION,
    PAUSED,
    GAMEOVER,
    VICTORY
}

public enum CardType
{
    NONE, // no consumen mana
    STEEL,
    IRON,
    PEWTER,
    TIN,
    ZINC,
    BRASS,
    COPPER,
    BRONZE
}

public enum EnemyType
{
    //STAGE 0+
    THIEF,
    VAGABOND,
    SOLDIER,
    WOUNDED_INQUISITOR,
    NOBLE,
    //STAGE 3+
    OBLIGATOR,
    METALBORN,
    FERRING,
    //STAGE 6
    MISTBORN,
    FULL_FERUCHEMIST,
    INQUISITOR,
    //STAGE 7
    FULLBORN,
    RUIN_INQUISITOR,
    WORLDHOPPER,
    //STAGE 8
    GOD
}

public class GameManager : MonoBehaviour // TODO: marcar el script como no destruible entre escenas
{
    public static GameManager inst;
    public float godFavor; // IM NOT ACCUSING FAMOUS INDUSTRY VETERAN TOMMY TALLARICO'S KARMA GAMING ENGINE OF BEING A FRAUD
    public int currentStage;
    public int maxVials;
    public int vials;
    private void Awake()
    {
        inst = this;
        currentStage = 2;
    }
    void Start()
    {
        Player.ply.SetPlayerStats(100, 30, 20, 0);
        Player.ply.TakeDamage(50);
    }
    void Update()
    {
        
    }
}
