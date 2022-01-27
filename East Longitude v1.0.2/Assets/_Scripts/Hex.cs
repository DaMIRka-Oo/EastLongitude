using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex : MonoBehaviour
{
    [SerializeField] private GameObject _highlight;


    void OnMouseEnter()
    {
        _highlight.SetActive(true);
    }

    void OnMouseExit()
    {
        _highlight.SetActive(false);
    }
}
