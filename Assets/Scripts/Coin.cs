using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static Action OnCoinTaked;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetType().ToString().Equals("UnityEngine.PolygonCollider2D"))
        {
            OnCoinTaked?.Invoke();
            Destroy(gameObject);
        }
    }

}
