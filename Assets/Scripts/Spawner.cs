using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CubePool))]
public class Spawner : MonoBehaviour
{
    [SerializeField] private float _spawnInterval = 0.2f;
    [SerializeField] private float _spawnAreaSize = 5f;
    [SerializeField] private float _spawnHeight = 10f;

    private CubePool _cubePool;

    private void Awake()
    {
        _cubePool = GetComponent<CubePool>();
    }

    private void Start() =>
        StartCoroutine(Countdown());

    private void SpawnCube()
    {
        Cube cube = _cubePool.GetCube();

        if (cube == null)
            return;

        float randomX = Random.Range(-_spawnAreaSize, _spawnAreaSize);
        float randomZ = Random.Range(-_spawnAreaSize, _spawnAreaSize);

        cube.transform.position = transform.position + new Vector3(randomX, _spawnHeight, randomZ);
        cube.transform.rotation = Quaternion.identity;
    }

    private IEnumerator Countdown()
    {
        WaitForSeconds wait = new WaitForSeconds(_spawnInterval);

        while (true)
        {
            SpawnCube();

            yield return wait;
        }
    }
}
