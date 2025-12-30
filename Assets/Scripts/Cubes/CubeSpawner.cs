using System;
using System.Collections;
using Generics.Spawners;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Cubes
{
    public class CubeSpawner : Spawner<Cube>
    {
        [SerializeField] private float _spawnInterval = 0.2f;
        [SerializeField] private float _spawnAreaSize = 5f;
        [SerializeField] private float _spawnHeight = 10f;
        
        private WaitForSeconds _wait;

        public event Action<Cube> Disabled;

        private void Start()
        {
            _wait = new WaitForSeconds(_spawnInterval);
            StartCoroutine(CooldownRotine());
        }
        
        public override Cube Spawn()
        {
            var cube = base.Spawn();

            var randomX = Random.Range(-_spawnAreaSize, _spawnAreaSize);
            var randomZ = Random.Range(-_spawnAreaSize, _spawnAreaSize);

            cube.transform.position = transform.position + new Vector3(randomX, _spawnHeight, randomZ);
            cube.Disabled += OnDisabled;
            
            return cube;
        }
        
        private IEnumerator CooldownRotine()
        {
            while (enabled)
            {
                Spawn();

                yield return _wait;
            }
        }

        private void OnDisabled(Cube cube)
        {
            Disabled?.Invoke(cube);
            cube.Disabled -= OnDisabled;
        }
    }
}
