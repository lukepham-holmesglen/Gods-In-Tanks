using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow : MonoBehaviour
{

    [Header("Slow Settings")]
    [SerializeField] private float _tankNormalSpeed = 12f;
    [SerializeField] private float _tankSlowSpeed = 2f;

    private List<GameObject> _affectedTanks = new List<GameObject>();

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
            _affectedTanks.Add(collision.gameObject);
            foreach (var affectedTank in _affectedTanks)
            {
                affectedTank.GetComponent<TankMovement>().m_Speed = _tankSlowSpeed;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        foreach (var affectedTank in _affectedTanks)
        {
            if (other.gameObject == affectedTank)
            {
                affectedTank.GetComponent<TankMovement>().m_Speed = _tankNormalSpeed;
                _affectedTanks.Remove(affectedTank);
            }
        }
    }





}
