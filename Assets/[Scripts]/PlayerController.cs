using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float Speed;
    public Vector2 velocity;

    private Vector3 _movementForce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        _movementForce = new Vector3(xAxis, yAxis, 0);

        Move();
    }

    private void Move()
    {
        velocity = _movementForce * Speed;
        GetComponent<Rigidbody2D>().velocity = velocity;
    }
}
