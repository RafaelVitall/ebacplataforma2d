using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    #region CODE

    public int startLife = 10;

    public bool destroyOnKill = false;

    int _currentLife;

    bool _isDead = false;

    private void Awake()
    {
        Init();
    }

    void Init()
    {
        _isDead = false;
        _currentLife = startLife;
    }

    public void Damage(int damage)
    {
        if (_isDead) return;

        _currentLife -= damage;

        if(_currentLife <= 0)
        {
            Kill();
        }
    }

    void Kill()
    {
        _isDead = true;

        if (destroyOnKill)
        {
            Destroy(gameObject);
        }
        else print("Dead");
    }

    #endregion
}
