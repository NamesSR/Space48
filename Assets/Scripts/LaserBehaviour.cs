using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class LaserBehaviour : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 500f;
    Transform tf;

    Movement movement;

    private void Start() {
        tf = gameObject.GetComponent<Transform>();
        movement = new Movement(false, moveSpeed, tf);
    }

    private void Update()
    {
        movement.Move();
    }
//test
}
