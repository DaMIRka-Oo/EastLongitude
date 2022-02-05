using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex : MonoBehaviour
{
    [SerializeField] private GameObject _highlight;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private SpriteRenderer _highglightRenderer;
    [SerializeField] private Color _baseColor, _offsetColor;

    public bool isActive;


    public void Init(bool isOffset)
    {
        //_renderer.color = isOffset ? _offsetColor : _baseColor;
    }


    private void Start()
    {
        isActive = false;
        _renderer.color = _baseColor;
        _highglightRenderer.color = _offsetColor;
    }

    private void OnMouseDown()
    {
        Debug.Log(isActive);
    }

    public void Update()
    {
       if (isActive)
            _renderer.enabled = true;       
       else
            _renderer.enabled = false;
    }
    void OnMouseEnter()
    {
        _highlight.SetActive(true);
    }

    void OnMouseExit()
    {
        _highlight.SetActive(false);
    }
}
