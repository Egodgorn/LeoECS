using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlayerComponent
{
    public Transform playertransform;
    public Rigidbody RB;
    public CharacterController CH;
    public Vector3 Velocity;
    public float speed;
    public float jumpspeed;
}