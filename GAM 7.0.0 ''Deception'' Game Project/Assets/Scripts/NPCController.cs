using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public enum State { Standing, Walking };
    public State currentState = State.Standing;
    public float timer;
    public float speed = 1;
    public float speedMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        speedMultiplier = Random.Range(50, 150) / 100f;
        timer = Random.Range(100, 500) / 100f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {

            ToggleState();
            float temp = Random.Range(25, 150) / 100.0f;
            timer = currentState == State.Walking ? temp * temp * speedMultiplier : temp * temp / speedMultiplier;
            print("State: " + currentState + ", Multiplier: " + speedMultiplier + ", timer: " + timer);
            if (currentState == State.Walking)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
            }
            else
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero * speed;
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    void ToggleState ()
    {
        currentState = currentState == State.Standing ? State.Walking : State.Standing;
    }
}
