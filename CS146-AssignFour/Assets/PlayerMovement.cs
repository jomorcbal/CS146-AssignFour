using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    const int UP = 1;
    const int LEFT = 2;
    const int DOWN = 3;
    const int RIGHT = 4;

    private Rigidbody2D rb;
    [SerializeField]
    private float movementSpeed;
    private Animator an;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        HandleMovement(horizontal, vertical);
    }

    private void HandleMovement(float h, float v)
    {
        rb.velocity = new Vector2(h * movementSpeed, v * movementSpeed);
        if (h > 0 && h > Mathf.Abs(v))
        {
            Debug.Log("Right");
            an.SetInteger("direction", RIGHT);
        } else if (h < 0 && Mathf.Abs(h) > Mathf.Abs(v))
        {
            Debug.Log("Left");
            an.SetInteger("direction", LEFT);
        }
        else if (v > 0)
        {
            Debug.Log("Up");
            an.SetInteger("direction", UP);
        }
        else if (v < 0)
        {
            Debug.Log("Down");
            an.SetInteger("direction", DOWN);
        } else
        {
            an.SetInteger("direction", 0);
        }
    }
}
