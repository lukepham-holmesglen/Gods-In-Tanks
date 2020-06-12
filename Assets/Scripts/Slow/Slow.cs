using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow : MonoBehaviour
{

    [Header("Slow Settings")]
    [SerializeField] private float _tankNormalSpeed = 12f;
    [SerializeField] private float _tankSlowSpeed = 2f;

    private GameObject _affectedTank;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _affectedTank = collision.gameObject;
            _affectedTank.GetComponent<TankMovement>().m_Speed = _tankSlowSpeed;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _affectedTank)
        {
            _affectedTank.GetComponent<TankMovement>().m_Speed = _tankNormalSpeed;
        }
    }





}
