using UnityEngine;

namespace Bombs
{
    public class Exploder : MonoBehaviour
    {
        [SerializeField] private float _explosionForce = 500f;
        [SerializeField] private float _explosionRadius = 5f;
        [SerializeField] private float _upwardsModifier = 1f;

        public void Boom(Bomb bomb)
        {
            var colliders = Physics.OverlapSphere(bomb.transform.position, _explosionRadius);

            foreach (var col in colliders)
                if (col.TryGetComponent<Rigidbody>(out var rigitbody))
                    rigitbody.AddExplosionForce(_explosionForce, bomb.transform.position, _explosionRadius, _upwardsModifier);
        }
    }
}
