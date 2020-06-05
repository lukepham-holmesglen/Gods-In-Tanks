using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [Header("General")]
    [SerializeField] powerUpType _powerUpType;
    [SerializeField] private float _powerUpTime = 5f;
    [SerializeField] Material _material;
    [Header("Speed Boost Settings")]
    [SerializeField] private float _tankNormalSpeed = 12f;
    [SerializeField] private float _tankBoostSpeed = 24f;
    [Header("Health Boost Settings")]
    [SerializeField] private float _healthIncrease = 100f;


    private GameObject _affectedTank;
    private MeshRenderer _meshRenderer;
    private Collider _collider;
    public enum powerUpType { SpeedBoost, HealthBoost};


    // Start is called before the first frame update
    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _collider = GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider collision) 
    {
        if (collision.gameObject.tag == "Player") 
        {
            switch (_powerUpType)
            {
                case powerUpType.SpeedBoost:
                    _affectedTank = collision.gameObject;
                    StartCoroutine(BoostTankSpeed());
                    break;
                case powerUpType.HealthBoost:
                    _affectedTank = collision.gameObject;
                    StartCoroutine(HealthBoostTank());
                    break;

            }
        }
    }


    IEnumerator BoostTankSpeed() 
    {
        _affectedTank.GetComponent<TankMovement>().m_Speed = _tankBoostSpeed;
        _meshRenderer.enabled = false;
        _collider.enabled = false;
        yield return new WaitForSeconds(_powerUpTime); 
        PowerUpOver();

    }

    IEnumerator HealthBoostTank() 
    {
        _affectedTank.GetComponent<TankHealth>().m_CurrentHealth = _healthIncrease;
        _affectedTank.GetComponent<TankHealth>().SetHealthUI();
        _meshRenderer.enabled = false;
        _collider.enabled = false;
        yield return new WaitForSeconds(_powerUpTime);
        PowerUpOver();

    }

    void PowerUpOver()
    {
        if (_powerUpType == powerUpType.SpeedBoost)
        {
            _affectedTank.GetComponent<TankMovement>().m_Speed = _tankNormalSpeed;
        }
        _meshRenderer.enabled = true;
        _collider.enabled = true;

    }

}
