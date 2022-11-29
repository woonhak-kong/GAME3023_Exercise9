using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private PlayerController playerController;

    private int direction = 0;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 velocity = playerController.velocity;
        int speed = 0;

        if (velocity.y > 0)
        {
            direction = 1;
        }
        else if (velocity.y < 0)
        {
            direction = 3;
        }
        else if (velocity.x < 0)
        {
            direction = 4;
        }
        else if (velocity.x > 0)
        {
            direction = 2;
        }

        
        speed = (int)(velocity.magnitude * 100);

        animator.SetInteger("direction", direction);
        animator.SetInteger("speed", speed);

        
    }
}
