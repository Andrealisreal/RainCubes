using System.Collections;
using Generics.Objects;
using UnityEngine;

namespace Bombs
{
    public class Bomb : GameEntity<Bomb>
    {
        protected override IEnumerator CooldownRoutine()
        {
            const float minValue = 0f;
        
            var startValue = Renderer.material.color.a;
            var speed = startValue / TimeCooldown;
            var color = Renderer.material.color;
    
            while (color.a > minValue)
            {
                var moveAmount = speed * Time.deltaTime;
    
                color.a = Mathf.MoveTowards(Renderer.material.color.a, minValue, moveAmount);
                Renderer.material.color = color;
            
                yield return null;
            }
        
            gameObject.SetActive(false);
        }
    }
}