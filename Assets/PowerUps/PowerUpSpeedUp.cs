using System.Collections;
using UnityEngine;

public class PowerUpSpeedUp : MonoBehaviour
{
    public GameObject Tank; //Allows the script to interact with this tank

    void Awake()
    {
        Tank = GameObject.FindGameObjectWithTag("Player");
    }

    void OnCollisionEnter(Collision collision) //deals with collision
    {
        if (collision.gameObject.tag == "Player") //if the player touches the object
        {
            Tank.GetComponent<TankMovement>().m_Speed = 24f; //Doubles the speed of the tank
            StartCoroutine(Speeder()); //start the speeder PowerUp
        }
    }

    IEnumerator Speeder() //allows waiting, Speed Up Power Up
    {
        yield return new WaitForSeconds(5); //wait for 5 seconds
        PowerUpOver();
    }

    void PowerUpOver()
    {
        Tank.GetComponent<TankMovement>().m_Speed = 12f; //Sets the tank speed back to normal
        Destroy(gameObject); //Destroys the Power Up so it can't be collected twice
    }
}
