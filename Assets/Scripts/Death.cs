using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private float timeToDeathDelay = 3f;
    [SerializeField] private float time;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        time = timeToDeathDelay;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ground" && rb.velocity.magnitude <= 10f)
        {
           time -= Time.deltaTime;
            if(time <= 0)
            {
                Debug.Log("Вы умерли. Примите свою смерть достойно");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            time = timeToDeathDelay;
        }
    }

}
