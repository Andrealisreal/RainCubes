using Bombs;
using Cubes;
using UnityEngine;

[RequireComponent(typeof(CubePool), typeof(CubeSpawner))]
[RequireComponent(typeof(BombsPool), typeof(BombsSpawner), typeof(Exploder))]
public class Game : MonoBehaviour
{
    private CubeSpawner _cubeSpawner;
    private BombsSpawner _bombsSpawner;
    private Exploder _exploder;

    private void Awake()
    {
        _cubeSpawner = GetComponent<CubeSpawner>();
        _bombsSpawner = GetComponent<BombsSpawner>();
        _exploder = GetComponent<Exploder>();
    }

    private void OnEnable()
    {
        _cubeSpawner.Disabled += SpawnBomb;
    }

    private void OnDisable()
    {
        _cubeSpawner.Disabled -= SpawnBomb;
    }

    private void SpawnBomb(Cube cube)
    {
        var bomb = _bombsSpawner.Spawn();

        bomb.transform.position = cube.transform.position;
        
        void OnBombExploded(Bomb explodedBomb)
        {
            _exploder.Boom(explodedBomb);
            explodedBomb.Exploded -= OnBombExploded;
        }
        
        bomb.Exploded += OnBombExploded;
    }
}
