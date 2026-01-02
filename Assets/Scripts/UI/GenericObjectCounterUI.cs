using Generics.Objects;
using Generics.Spawners;
using TMPro;
using UnityEngine;

namespace UI
{
    public abstract class GenericObjectCounterUI<T> : MonoBehaviour where T : Component
    {
        [SerializeField] private TextMeshProUGUI _spawnCountText;
        [SerializeField] private TextMeshProUGUI _createdCountText;
        [SerializeField] private TextMeshProUGUI _activeCountText;
        
        [SerializeField] private Spawner<T> _spawner;
        [SerializeField] private ObjectsPool<T> _pool;

        private void OnEnable()
        {
            _spawner.Spawned += UpdateSpawnCount;
            _pool.Created += UpdateCreatedCount;
            _pool.Activated += UpdateActiveCount;
        }

        private void OnDisable()
        {
            _spawner.Spawned -= UpdateSpawnCount;
            _pool.Created -= UpdateCreatedCount;
            _pool.Activated -= UpdateActiveCount;
        }

        private void UpdateSpawnCount(int value) => 
            _spawnCountText.text = $"{value}";
        
        private void UpdateCreatedCount(int value) => 
            _createdCountText.text = $"{value}";
        
        private void UpdateActiveCount(int value) => 
            _activeCountText.text = $"{value}";
    }
}
