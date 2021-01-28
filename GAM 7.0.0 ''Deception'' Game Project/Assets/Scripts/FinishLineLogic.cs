using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineLogic : MonoBehaviour
{
    // Check If Collided Object has a Tag that matches
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player_Runner")
        {
            Debug.Log("Player Runner Has Crossed The Finish Line");
        }
        else if (collision.gameObject.tag == "NPC_Runner")
        {
            Debug.Log("NPC Runner Has Crossed The Finish Line");
        }
    }
    // More will be added once more of the game is completed
}
