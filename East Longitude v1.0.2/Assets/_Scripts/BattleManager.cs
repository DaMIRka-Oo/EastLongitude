using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance;
    public BattleState State;

    public static event System.Action<BattleState> OnBattleStateChanged;

    public GameObject hero;
    public GameObject hex;

    Hero hero1;

    Vector3 startPosition;
    Vector3 endPosition;
    bool isMove;

    // Start is called before the first frame update
    void Start()
    {
        isMove = false;
        Invoke("PutHero", 0.1f);
        //UpdateBattleState(BattleState.General);
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (isMove)
        {
            hero.transform.position = Vector3.Lerp(startPosition, endPosition, 5*Time.deltaTime);
            startPosition = Vector3.Lerp(startPosition, endPosition, 5 * Time.deltaTime);
            if (startPosition == endPosition)
                isMove = false;
        }
        
    }


    private void PutHero()
    {
        int x = UnityEngine.Random.Range(0, 5);
        int y = UnityEngine.Random.Range(0, 3);
        hero = GameObject.Find("Hero");
        hex = GameObject.Find($"Hex {y} {x}");
        CreateHero(x, y);
        hero.transform.position = hex.transform.position;
        hero.transform.position += new Vector3(0, hero.transform.localScale.y * 14);
        startPosition = hero.transform.position;
    }

    public void UpdateBattleState(BattleState newState)
    {
        //Debug.Log(newState);
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
        for (int i = 0; i < 15; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                GameObject newHex = GameObject.Find($"Hex {j} {i}");
                newHex.GetComponent<Hex>().isActive = false;
            }
        }
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
        
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (x_Hexs_Choise[i] >= 0 && x_Hexs_Choise[i] < 15 && y_Hexs_Choise[j] >= 0 && y_Hexs_Choise[j] < 4)
                {
                    GameObject newHex = GameObject.Find($"Hex {y_Hexs_Choise[j]} {x_Hexs_Choise[i]}");
                    newHex.GetComponent<Hex>().isActive = true;
                }
                
            }
        }

    }


    public void MoveHero(int y, int x)
    {
       // Debug.Log($"Hex {y} {x}");
       // Debug.Log(' ');
        hex = GameObject.Find($"Hex {y} {x}");
        CreateHero(x, y);

        endPosition = hex.transform.position;
        endPosition += new Vector3(0, hero.transform.localScale.y * 14);
        isMove = true;

        UpdateBattleState(BattleState.General);
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
