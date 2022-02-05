using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexManager : MonoBehaviour
{
    [SerializeField] private float _width, _height;

    [SerializeField] private float _Xstart, _Ystart, _Xstep, _Ystep, _shift;

    [SerializeField] private Hex _hexPrefab;

    [SerializeField] private Transform _cam;

    void Start()
    {
        GenerateGrid();
    }

    public void GenerateGrid()
    {
        for (float y = _Ystart, i = 0; i < _height; y -= _Ystep, i++)
        {
            float shift = 0;
            if (i % 2 != 0) shift = _shift;

            for (float x = shift + _Xstart, j = 0; j < _width; x += _Xstep, j++)
            {
                var spawnedTile = Instantiate(_hexPrefab, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Hex {i} {j}";


                var isOffset = (i % 2 == 0 && j % 2 != 0) || (i % 2 != 0 && j % 2 == 0);
                spawnedTile.Init(isOffset);
            }
        }
    }
}
