using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _timeToDestroyBullet = 10f;
    private float _bulletDamage = 1f;

    public float BulletDamage { get => _bulletDamage; set => _bulletDamage = value; }


    private void Start()
    {
        StartCoroutine(DestroyBulletAfterTime());
    }

    private IEnumerator DestroyBulletAfterTime()
    {
        yield return new WaitForSeconds(_timeToDestroyBullet);
        DestroyBullet();
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        EnemyTest enemy = collision.gameObject.GetComponent<EnemyTest>();
        if (enemy)
        {
            enemy.TakeDamage(_bulletDamage);
        }

        DestroyBullet();
    }
}
