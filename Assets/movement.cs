using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float movespeed = 0.66f;
    public float turnspeed = 60f;
    public SpriteRenderer rend;
    public Color col;
    int timer = 0;

    // Use this for initialization
    void Start()
    {
        movespeed = Random.Range(1, 2.5f);
        InvokeRepeating("Timer", 1, 1);
    }

    void Timer()
    {
        Debug.Log("Timer:" + timer * Time.deltaTime);        
    }

    // Update is called once per frame
    void Update()
    {
        movespeed += 0.00001f * timer;
        turnspeed += 0.0001f * timer;
        timer += 1;
        transform.Translate(Vector2.up * movespeed * Time.deltaTime);

        if (movespeed > 8)
        {
            movespeed = 8;
        }

        if (turnspeed > 167)
        {
            turnspeed = 167;
        }

        if (Input.GetKeyDown(KeyCode.S))
            {
                movespeed /= 2;
            }

            if (Input.GetKeyUp(KeyCode.S))
            {
                movespeed *= 2;
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0, 0, -turnspeed * Time.deltaTime);
                rend.color = new Color(0, 0, 1);
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0, 0, turnspeed * Time.deltaTime * 0.9f);
                rend.color = new Color(0, 1, 0);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
            rend.color = new Color(Random.value, Random.value, Random.value);
            }
    }
}
