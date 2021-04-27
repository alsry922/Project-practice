using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Movement2D movement2D;
    private float originPosX;

    public float OriginPosX
    {
        get => originPosX;
    }

    private void Awake()
    {
        movement2D = GetComponent<Movement2D>();
        originPosX = transform.position.x;
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");

        movement2D.Move(x);
    }

    public float getStartPosX()
    {
        return originPosX;
    }
}
