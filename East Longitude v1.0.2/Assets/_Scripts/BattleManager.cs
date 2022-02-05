using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance;
    public BattleState State;

    public static event System.Action<BattleState> OnBattleStateChanged;

    [SerializeField] private SpriteRenderer _renderer;



    public GameObject hero;
    public GameObject hex;

    Hero hero1;

    // Start is called before the first frame update
    void Start()
    {
        UpdateBattleState(BattleState.General);
        
        Invoke("PutHero", 0.1f);
    }

    private void Awake()
    {
        Instance = this;
       // Debug.Log(1);
    }


    public void PutHero()
    {
        int x = UnityEngine.Random.Range(0, 5);
        int y = UnityEngine.Random.Range(0, 3);
        hero = GameObject.Find("Hero");
        hex = GameObject.Find($"Hex {y} {x}");
        CreateHero(x, y);
        hero.transform.position = hex.transform.position;
        hero.transform.position += new Vector3(0, hero.transform.localScale.y * 14);
    }

    public void UpdateBattleState(BattleState newState)
    {
        Debug.Log(newState);
        State = newState;

        switch (newState)
        {
            case BattleState.General:
                DropExtraElements();
                break;
            case BattleState.Move:
                ChoiseLoc();
                break;
            case BattleState.Shot:
                break;
            default:
                throw new System.ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnBattleStateChanged?.Invoke(newState);
    }

    private void DropExtraElements()
    {

    }

    private void ChoiseLoc()
    {
        int[] x_Hexs_Choise = new int[3];
        int[] y_Hexs_Choise = new int[3];

        for (int i = 0; i < 3; i++)
        {
            x_Hexs_Choise[i] = hero1.X_Hex - 1 + i;
            y_Hexs_Choise[i] = hero1.Y_Hex - 1 + i;
        }
        

    }

    private void CreateHero(int x, int y)
    {
        hero1 = hero.AddComponent<Hero>();
        hero1.X_Hex = x;
        hero1.Y_Hex = y;
    }

}

public enum BattleState{
    General,
    Move,
    Shot
}
