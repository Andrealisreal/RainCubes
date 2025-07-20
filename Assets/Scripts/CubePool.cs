using System.Collections.Generic;
using UnityEngine;

public class CubePool : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private int _initialPoolSize = 30;

    private List<Cube> _pool = new List<Cube>();

    private void Awake()
    {
        for (int i = 0; i < _initialPoolSize; i++)
            CreateCube();
    }

    public Cube GetCube()
    {
        foreach (Cube cube in _pool)
        {
            if (cube.gameObject.activeInHierarchy == false)
            {
                cube.gameObject.SetActive(true);

                return cube;
            }
        }

        return CreateCube();
    }

    private Cube CreateCube()
    {
        Cube cube = Instantiate(_cubePrefab, transform);
        cube.gameObject.SetActive(false);
        _pool.Add(cube);

        return cube;
    }
}
