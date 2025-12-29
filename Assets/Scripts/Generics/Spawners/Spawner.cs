using Generics.Objects;
using UnityEngine;

namespace Generics.Spawners
{
    public class Spawner<T> : MonoBehaviour where T : Component
    {
        [SerializeField] protected ObjectsPool<T> ObjectsPool;
        
        protected T CurrentItem;

        protected virtual void Spawn()
        {
            CurrentItem = ObjectsPool.GetObject();
        }
    }
}
