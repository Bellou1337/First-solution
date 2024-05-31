using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.Profiling;
using UnityEngine;

public abstract class PlayerControler : MonoBehaviour
{
    protected Rigidbody rb { get; set; }
    private float _hp = 100;
    private float _speed = 5;
    private float _weight = 1;
    private float _jump_force = 1;
    private float _ray_length = 1.01f;
    public float hp
    { 
        get { return _hp; }
        set { _hp = value > 0 ? value : 0; }
    }
    public float speed
    {
        get { return _speed; }
        set { _speed = value > 0 ? value : 0; }
    }
    public float weight
    {
        get { return _weight; }
        set { _weight = value > 0 ? value : 0; }
    }
    public float jump_force
    {
        get { return _jump_force; }
        set { _jump_force = value > 0 ? value : 0; }
    }
    public float ray_length
    {
        get { return _ray_length; }
        set { _ray_length = value > 0 ? value : 0; }
    }

    [SerializeField] protected ControlKeys keys;

    protected void setup()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = weight;
        keys = RandomControl.get_rand_control_player();
    }

    bool is_grounded()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, ray_length))
        {
            return true;
        }
        return false;
    }

    protected void move_player()
    {
        if (Input.GetKey(keys.move_right))
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(speed, 0, 0), Time.deltaTime * speed);
        }
        if (Input.GetKey(keys.move_left))
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(-speed, 0, 0), Time.deltaTime * speed);
        }
        if (Input.GetKey(keys.move_forward))
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(0, 0, speed), Time.deltaTime * speed);
        }
        if (Input.GetKey(keys.move_backward))
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(0, 0, -speed), Time.deltaTime * speed);
        }

        if (Input.GetKeyDown(keys.jump) && is_grounded())
        {
            rb.AddForce(Vector3.up * jump_force, ForceMode.Impulse);
        }
    }
}