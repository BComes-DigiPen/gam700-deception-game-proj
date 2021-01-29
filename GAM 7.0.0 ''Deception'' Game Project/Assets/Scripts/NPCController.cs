using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public enum State { Standing, Walking };
    public State currentState = State.Standing;
    public float timer = 0;
    public float speed = 1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            float temp = Random.Range(25, 150) / 100.0f;
            timer = temp * temp;
            //print(temp + ", " + temp * temp);
            ToggleState();
            if (currentState == State.Standing)
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
