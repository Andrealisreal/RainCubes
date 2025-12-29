using System.Collections;
using UnityEngine;

namespace Generics.Objects
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Renderer))]
    public abstract class GameEntity<T> : MonoBehaviour
    {
        [SerializeField] protected float MinLifeTime = 2f;
        [SerializeField] protected float MaxLifeTime = 5f;
        
        protected Renderer Renderer;
        
        protected float TimeCooldown;
        
        private Rigidbody _rigidbody;
        private WaitForSeconds _wait;
        
        private void Awake()
        {
            Renderer = GetComponent<Renderer>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            TimeCooldown = Random.Range(MinLifeTime, MaxLifeTime);
            _wait = new WaitForSeconds(TimeCooldown);
        }

        protected virtual void OnDisable()
        {
            ResetDefaults();
        }

        protected virtual void ResetDefaults()
        {
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.identity;

            _rigidbody.linearVelocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
        }
        
        protected virtual IEnumerator CooldownRoutine()
        {
            yield return _wait;
            
            gameObject.SetActive(false);
        }
    }
}
