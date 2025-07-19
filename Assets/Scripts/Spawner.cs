using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _spawnInterval = 0.2f;
    [SerializeField] private float _spawnAreaSize = 5f;
    [SerializeField] private float _spawnHeight = 10f;

    private void Start() =>
        InvokeRepeating(nameof(SpawnCube), 0f, _spawnInterval);

    private void SpawnCube()
    {
        Cube cube = CubePool.Instance.GetCube();

        if (cube == null)   
            return;

        float randomX = Random.Range(-_spawnAreaSize, _spawnAreaSize);
        float randomZ = Random.Range(-_spawnAreaSize, _spawnAreaSize);

        cube.transform.position = transform.position + new Vector3(randomX, _spawnHeight, randomZ);
        cube.transform.rotation = Quaternion.identity;
    }
}
