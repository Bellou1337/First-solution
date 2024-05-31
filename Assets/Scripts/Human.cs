using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : PlayerControler
{
    protected float hp = 10f;
    private Human()
    {
        hp = 10f;
        speed = 10f;
        weight = 5f;
        jump_force = 10f;
        ray_length = 1.01f;

    }

    public void Start()
    {
        setup();
    }

    public void Update()
    {
        move_player();
    }
}
