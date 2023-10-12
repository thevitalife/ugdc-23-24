using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float damage;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Rigidbody rigidbody;

    [SerializeField]
    private ParticleSystem explosion;

    [SerializeField]
    private MeshRenderer meshRenderer;

    [SerializeField]
    private Collider collider;

    private void Start()
    {
        Move();
    }

    public void Move()
    {
        rigidbody.AddForce(transform.up * speed, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Detect(collision.collider);
    }

    public void Detect(Collider collider)
    {
        if (collider.TryGetComponent(out HitBody hitBody))
        {
            hitBody.Damage(damage);
        }
        Explode();
    }

    private void Explode()
    {
        explosion.Play();
        rigidbody.isKinematic = true;
        collider.enabled = false;
        meshRenderer.enabled = false;
    }
}
