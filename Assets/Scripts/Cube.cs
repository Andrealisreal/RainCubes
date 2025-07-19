using UnityEngine;

public class Cube : MonoBehaviour
{
    private Renderer _renderer;
    private Rigidbody _rigidbody;

    private Color _defaultColor = Color.white;

    private float _lifeTime = 10f;
    private float _minLifeTime = 2f;
    private float _maxLifeTime = 5f;
    private float _timeAfterContact;

    private bool _hasColorChange = false;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        Invoke(nameof(ReturnToPool), _lifeTime);
        _timeAfterContact = Random.Range(_minLifeTime, _maxLifeTime);
    }

    private void OnDisable()
    {
        CancelInvoke();
        ResetDefaults();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform") && _hasColorChange == false)
        {
            Invoke(nameof(ReturnToPool), _timeAfterContact);
            _renderer.material.color = new Color(Random.value, Random.value, Random.value);
            _hasColorChange = true;
        }
    }

    private void ResetDefaults()
    {
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;

        _rigidbody.linearVelocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;

        _renderer.material.color = _defaultColor;
        _hasColorChange = false;
    }

    private void ReturnToPool() =>
        CubePool.Instance.ReturnCube(this);
}
