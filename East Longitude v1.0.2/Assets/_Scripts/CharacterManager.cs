using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private Character _character;

    void Start()
    {
        
        CreateCharacter();
    }
    public void CreateCharacter()
    {
        
        System.Random rnd = new System.Random();

        int i = rnd.Next(5);
        int j = rnd.Next(4);

        GameObject go = GameObject.Find($"Hex {i} {j}");
        var spawnedTile = Instantiate(_character, new Vector3(go.transform.position.x, go.transform.position.y), Quaternion.identity);
        spawnedTile.name = $"Grand character";
       // yield return new WaitForSeconds(5);

    }

}
