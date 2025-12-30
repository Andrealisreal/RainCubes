using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Generics.Objects
{
    public abstract class ObjectsPool<T> : MonoBehaviour where T : Component
    {
        [SerializeField] private T _prefab;
        [SerializeField] private int _initialPoolSize = 30;

        private readonly List<T> _pool = new();

        private int _numberCreatedObjects;
        private int _numberActiveObjects;

        public event Action<int> Created;
        public event Action<int> Activated;

        private void Awake()
        {
            for (var i = 0; i < _initialPoolSize; i++)
                Create();
        }

        public T GetObject()
        {
            foreach (var item in _pool)
            {
                if (item.gameObject.activeInHierarchy)
                    continue;

                CountActiveObjects();
                item.gameObject.SetActive(true);

                return item;
            }

            return Create();
        }

        private T Create()
        {
            var item = Instantiate(_prefab, transform);
            item.gameObject.SetActive(false);
            _pool.Add(item);
            CountCreatedObjects();

            return item;
        }

        private void CountActiveObjects()
        {
            int count = 0;
            
            foreach (var item in _pool)
                if (item.gameObject.activeInHierarchy)
                    count++;

            Activated?.Invoke(count);
        }

        private void CountCreatedObjects()
        {
            _numberCreatedObjects++;
            Created?.Invoke(_numberCreatedObjects);
        }
    }
}