using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBody : MonoBehaviour
{
    [SerializeField]
    private float hp;

    [SerializeField]
    private ParticleSystem explosion;

    [SerializeField]
    private Renderer renderer;

    [SerializeField]
    private Collider collider;

    public void Damage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        explosion.Play();
        renderer.enabled = false;
        collider.enabled = false;
    }
}
