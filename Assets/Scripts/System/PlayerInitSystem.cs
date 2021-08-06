using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInitSystem : IEcsInitSystem
{
    private EcsWorld ecsWorld;

    public void Init()
    {
        var player = ecsWorld.NewEntity();

        ref var playercomponent = ref player.Get<PlayerComponent>();
        ref var playerinputcomponent = ref player.Get<PlayerInputComponent>();

        var sceneplayer = GameObject.FindGameObjectWithTag("Player");

        playercomponent.speed = 0.1f;
        playercomponent.jumpspeed = 5;
        playercomponent.playertransform = sceneplayer.transform;
        playercomponent.RB = sceneplayer.GetComponent<Rigidbody>();
        playercomponent.CH = sceneplayer.GetComponent<CharacterController>();
        


    }


}
