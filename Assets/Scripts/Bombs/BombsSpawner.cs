using Cubes;
using Generics.Spawners;
using UnityEngine;

namespace Bombs
{
    public class BombsSpawner : Spawner<Bomb>
    {
        [SerializeField] private Cube _cube;

        private void OnEnable()
        {
            _cube.IsDisabled += Spawn;
        }

        private void OnDisable()
        {
            _cube.IsDisabled -= Spawn;
        }

        protected override void Spawn()
        {
            base.Spawn();
            
            CurrentItem.transform.position = _cube.transform.position;
        }
    }
}
