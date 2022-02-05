using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexManager2 : MonoBehaviour
{
    [SerializeField] private GameObject _gameField;
    [SerializeField] private Hex _hexPrefab;


    // _shift;

    RectTransform rt;

    void Start()
    {
        
        //Debug.Log(_gameField.transform.localScale);
        Debug.Log(_gameField.transform.position);
        Debug.Log(_gameField.transform.localScale);
        GenerateGrid();
    }
    public void GenerateGrid()
    {
        float _width = 15, _height = 4;
        float _Xstart = _gameField.transform.position.x - _gameField.transform.localScale.x / 3,
            _Ystart = _gameField.transform.position.y + _gameField.transform.localScale.y / 4;
        Debug.Log(_Xstart);
        Debug.Log(_Ystart);
        float _Xstep = _gameField.transform.localScale.x / _width, _Ystep = _gameField.transform.localScale.y / _height;
        float _shift = _Xstep / 2;
        for (float y = _Ystart, i = 0; y > _Ystart - _height * _Ystep; y -= _Ystep, i++)
        {
            float shift = 0;
            if (i % 2 != 0) shift = _shift;

            for (float x = shift + _Xstart, j = 0; x < shift + _Xstart + _width * _Xstep; x += _Xstep, j++)
            {
                var spawnedTile = Instantiate(_hexPrefab, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Hex {i} {j}";

            }
        }
    }

}
