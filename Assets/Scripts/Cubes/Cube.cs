using System;
using Generics.Objects;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Cubes
{
    public class Cube : GameEntity<Cube>
    {
        private readonly Color _defaultColor = Color.white;

        private bool _hasColorChange;

        public event Action<Cube> Disabled;
        
        private void OnCollisionEnter(Collision collision)
        {
            if (_hasColorChange || collision.gameObject.GetComponent<Platform>() == false) 
                return;
            
            StartCoroutine(CooldownRoutine());
            Renderer.material.color = Random.ColorHSV();
            _hasColorChange = true;
        }
        
        protected override void ResetDefaults()
        {
            Disabled?.Invoke(this);
            base.ResetDefaults();
            Renderer.material.color = _defaultColor;
            _hasColorChange = false;
        }
    }
}
