using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private GameObject _deathMesh;

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
            _affectedTank.GetComponent<TankHealth>().OnDeath();
            _deathMesh.transform.position = new Vector3(0f, 0f, 0f);
        }
    }

}
