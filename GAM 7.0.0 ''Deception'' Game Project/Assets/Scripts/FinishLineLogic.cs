using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineLogic : MonoBehaviour
{
    public string Player_Tag;
    public string NPC_Tag;
    private string Winner;
    public bool Player_Victory = false;
    public bool NPC_Victory = false;
    public bool Victory = false;
    // Check If Collided Object has a Tag that matches
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (Victory != true)
        {
            if (collision.gameObject.tag == Player_Tag)
            {
                //GetComponent<Collider2D>().enabled = false;
                Player_Victory = true;
                Victory = true;
                Winner = collision.gameObject.tag;
                Debug.Log(Winner + " Has Won!");
                GameManager.SetState(GameState.RunnerVictory);
            }
            if (collision.gameObject.tag == NPC_Tag)
            {
                //GetComponent<Collider2D>().enabled = false;
                NPC_Victory = true;
                Victory = true;
                Winner = collision.gameObject.tag;
                Debug.Log(Winner + " Has Won!");
                GameManager.SetState(GameState.NPCVictory);
            }

        }
    }
}
