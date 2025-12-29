using System.Collections;
using Generics.Spawners;
using UnityEngine;

namespace Cubes
{
    public class CubeSpawner : Spawner<Cube>   
    {
        [SerializeField] private float _spawnInterval = 0.2f;
        [SerializeField] private float _spawnAreaSize = 5f;
        [SerializeField] private float _spawnHeight = 10f;
        
        private WaitForSeconds _wait;

        private void Start()
        {
            _wait = new WaitForSeconds(_spawnInterval);
            StartCoroutine(CooldownRotine());
        }
        
        protected override void Spawn()
        {
            base.Spawn();
            
            if (CurrentItem == null)
                return;

            var randomX = Random.Range(-_spawnAreaSize, _spawnAreaSize);
            var randomZ = Random.Range(-_spawnAreaSize, _spawnAreaSize);

            CurrentItem.transform.position = transform.position + new Vector3(randomX, _spawnHeight, randomZ);
        }
        
        private IEnumerator CooldownRotine()
        {
            while (enabled)
            {
                Spawn();

                yield return _wait;
            }
        }
    }
}
