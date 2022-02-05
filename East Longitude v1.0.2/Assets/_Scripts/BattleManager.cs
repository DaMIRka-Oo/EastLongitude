using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{

    public GameObject hero;
    public GameObject hex;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("PutHero", 0.1f);
    }


    public void PutHero()
    {
        int x = UnityEngine.Random.Range(0, 5);
        int y = UnityEngine.Random.Range(0, 3);
        hero = GameObject.Find("Hero");
        //Vector3 shift = Vector3(hero.transform.localScale.x / 2, hero.transform.localScale.y / 2);
        hex = GameObject.Find($"Hex {y} {x}");
        Debug.Log($"Hex {y} {x}");
        hero.transform.position = hex.transform.position;
        hero.transform.position += new Vector3(0, hero.transform.localScale.y * 14);
       // Debug.Log(hero.transform.position);
    }

}
