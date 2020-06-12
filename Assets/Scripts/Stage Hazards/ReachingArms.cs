using UnityEngine;

public class ReachingArms : MonoBehaviour
{
    private GameObject _affectedTank;
    private MeshRenderer _meshRenderer;
    private float Timer = 0f;

    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshRenderer.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        Timer = 0f;
    }

    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _affectedTank = collision.gameObject;
            Timer += Time.deltaTime;
            if (Timer > 5)
            {
                DeathHands();
            }
        }
    }

    void DeathHands()
    {
        _affectedTank.GetComponent<TankHealth>().m_CurrentHealth = -10;
        _affectedTank.GetComponent<TankHealth>().SetHealthUI();
        _meshRenderer.enabled = true;
    }
}