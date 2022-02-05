using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    private int x_Hex, y_Hex;

    public int X_Hex
    {
        get
        {
            return x_Hex;
        }
        set
        {
            x_Hex = value;
        }
    }

    public int Y_Hex
    {
        get
        {
            return y_Hex;
        }
        set
        {
            y_Hex = value;
        }
    }

}
