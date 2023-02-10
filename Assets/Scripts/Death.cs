using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public Action OnPlayerDead;
    public Action<float> OnDeathTimeChanged;
    [SerializeField] private float timeToDeathDelay = 3f;
    [SerializeField] private float time;

    private bool isDead;

    private Rigidbody2D rb;

    public float Time { get => time;}
    public bool IsDead { get => isDead;}

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        time = timeToDeathDelay;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ground" && rb.velocity.magnitude <= 10f)
        {
            time -= UnityEngine.Time.deltaTime;
            OnDeathTimeChanged(time);
            if (Time <= 0 && !isDead)
            {
                OnPlayerDead?.Invoke();
                isDead = true;
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
