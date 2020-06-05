using System.Collections;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject PowerUp; //Allows a prefab to be added and called PowerUp
    public Transform PowerUpSpawn; //allows something to be set as the location

    void Start() //first frame of the game
    {
        StartCoroutine(PUS()); //starts the Power Up Spawning timer at the first frame
    }

    IEnumerator PUS() //allows waiting, Power Up Spawning timer
    {
        yield return new WaitForSeconds(5); //waits 5 seconds before continuing
        Instantiate(PowerUp, PowerUpSpawn.position, PowerUpSpawn.rotation); //spawns the powerup
    }
    
    void OnCollisionEnter(Collision collision) //deals with collision
    {
        if (collision.gameObject.tag == "Player") //if the player touches the object
        {
            StartCoroutine(PUW()); //starts the Power Up Waiter timer when the player touches the object
        }
    }

    IEnumerator PUW() //allows waiting, Power Up Waiter
    {
        yield return new WaitForSeconds(2); //waits 2 seconds before continuing
        StartCoroutine(PUS()); //starts the Power Up Spawning timer
    }
}
