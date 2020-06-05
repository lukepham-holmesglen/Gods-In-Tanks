using UnityEngine;

public class PowerUpRemover : MonoBehaviour
{

    void OnCollisionEnter(Collision collision) //deals with collision
    {
        if (collision.gameObject.tag == "Player") //if the player touches the object
        {
            Destroy(gameObject); //Destroys the Power Up so it can't be collected twice
        }
    }
}
