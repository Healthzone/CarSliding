using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBalance : MonoBehaviour
{
    [SerializeField] CircleCollider2D _leftWheel;
    [SerializeField] CircleCollider2D _rightWheel;


    private void OnCollisionStay2D(Collision2D collision)
    {
        //if (collision.collider.IsTouching(_leftWheel) || collision.collider.IsTouching(_rightWheel))
        //{
        //    if (transform.rotation.eulerAngles.z < -30f && transform.rotation.eulerAngles.z > 20)
        //        transform.rotation = Quaternion.Euler(Vector3.zero);
        //}
    }

}
