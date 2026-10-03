using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool isShip { get; set; }

   public float moveSpeed { get; set; }
   Transform tf { get; set; }


    public Movement(bool isship,float speed, Transform sd){
        isShip = isship;
        moveSpeed = speed;
        tf = sd;
    }
    public void Move()
    {
        if(isShip)
        {
            tf.position = tf.position + tf.forward * moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        }else
        {
             tf.position = tf.position + tf.forward * moveSpeed * Time.deltaTime;
        }
    }
}
