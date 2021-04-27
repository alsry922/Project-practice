using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainerControl : MonoBehaviour
{
    private float originPosX;
    private float startPosX;
    Movement2D movement2D;

    public float OriginPosX
    {
        get => originPosX;
    }

    public float StartPosX
    {
        get => startPosX;
        set => startPosX = value;
    }

    
    private void Awake()
    {
        originPosX = transform.position.x;
        startPosX = transform.position.x;
        movement2D = GameObject.Find("Player").GetComponent<Movement2D>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
