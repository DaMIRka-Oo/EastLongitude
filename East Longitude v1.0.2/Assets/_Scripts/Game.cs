using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    HexManager hexM = new HexManager();
    CharacterManager charM = new CharacterManager();
    // Start is called before the first frame update
    void Start()
    {
        hexM.GenerateGrid();
        charM.CreateCharacter();
    }

}
