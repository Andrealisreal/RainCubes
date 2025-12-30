using Cubes;
using TMPro;
using UnityEngine;

namespace Generics
{
    public class TextBar : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _numSpawn;
        [SerializeField] private TextMeshProUGUI _numCreate;
        [SerializeField] private TextMeshProUGUI _numActive;
        
        [SerializeField] private CubeSpawner _cubeSpawner;
        [SerializeField] private CubePool _cubePool;

        private void OnEnable()
        {
            _cubeSpawner.Spawned += UpdateSpawnCount;
            _cubePool.Created += UpdateCreatedCount;
            _cubePool.Activated += UpdateActiveCount;
        }

        private void OnDisable()
        {
            _cubeSpawner.Spawned -= UpdateSpawnCount;
            _cubePool.Created -= UpdateCreatedCount;
            _cubePool.Activated -= UpdateActiveCount;
        }

        private void UpdateSpawnCount(int value)
        {
            _numSpawn.text = $"{value}";
        }

        private void UpdateCreatedCount(int value)
        {
            _numCreate.text = $"{value}";
        }

        private void UpdateActiveCount(int value)
        {
            _numActive.text = $"{value}";
        }
    }
}