using TMPro;
using UnityEngine;
using Cubes;
using Bombs;

namespace UI
{
    public class ObjectCounterUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _spawnCountText;
        [SerializeField] private TextMeshProUGUI _createdCountText;
        [SerializeField] private TextMeshProUGUI _activeCountText;

        [SerializeField] private CounterType _counterType;

        [SerializeField] private CubeSpawner _cubeSpawner;
        [SerializeField] private CubePool _cubePool;

        [SerializeField] private BombsSpawner _bombSpawner;
        [SerializeField] private BombsPool _bombPool;

        private enum CounterType
        {
            Cubes,
            Bombs
        }

        private void OnEnable()
        {
            switch (_counterType)
            {
                case CounterType.Cubes:
                    _cubePool.Created += UpdateCreatedCount;
                    _cubePool.Activated += UpdateActiveCount;
                    _cubeSpawner.Spawned += UpdateSpawnCount;
                    break;

                case CounterType.Bombs:
                    _bombPool.Created += UpdateCreatedCount;
                    _bombPool.Activated += UpdateActiveCount;
                    _bombSpawner.Spawned += UpdateSpawnCount;
                    break;
            }
        }

        private void OnDisable()
        {
            switch (_counterType)
            {
                case CounterType.Cubes:
                    _cubePool.Created -= UpdateCreatedCount;
                    _cubePool.Activated -= UpdateActiveCount;
                    _cubeSpawner.Spawned -= UpdateSpawnCount;
                    break;

                case CounterType.Bombs:
                    _bombPool.Created -= UpdateCreatedCount;
                    _bombPool.Activated -= UpdateActiveCount;
                    _bombSpawner.Spawned -= UpdateSpawnCount;
                    break;
            }
        }

        private void UpdateSpawnCount(int value) => _spawnCountText.text = $"{value}";
        private void UpdateCreatedCount(int value) => _createdCountText.text = $"{value}";
        private void UpdateActiveCount(int value) => _activeCountText.text = $"{value}";
    }
}