using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    // public
    public Enemies Enemy;

    // private
    private float _bulletSpeed = SettingsController.TowerBulletSpeed;
    private float _bulletTimeLife = SettingsController.TowerBulletTimeLife;
    private float _bulletDamage = SettingsController.TowerBulletDamage;
    private float _bulletTimerLife;


    void Start()
    {
        _bulletTimerLife = _bulletTimeLife;
    }

    void Update()
    {
        if(Enemy == null)
        {
            Destroy(gameObject);
            return;
        }

        _bulletTimerLife -= Time.deltaTime;

  

        Vector3 dir = Enemy.transform.position - transform.position;
        float _speed = _bulletSpeed * Time.deltaTime;

        if (_bulletTimerLife <= 0)
        {

            // время жизни пули закончилось
            _bulletTimerLife = _bulletTimeLife;
            Destroy(gameObject);
        }
        else if (Mathf.Round(dir.magnitude) <= _speed)
        // else if (Enemy != null && (Vector3.Distance(transform.position, Enemy.transform.position) <= _speed))
        {
            if (Enemy != null)
            {
                // пул попала в ццель
                Enemy.SetDamage(_bulletDamage);
                Destroy(gameObject);
                return;
            }

        }

        transform.Translate(new Vector3(0, 0, _bulletSpeed));
    }
}
