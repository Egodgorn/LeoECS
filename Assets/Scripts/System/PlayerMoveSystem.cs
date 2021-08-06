using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

public class PlayerMoveSystem : IEcsRunSystem
{
    private EcsFilter<PlayerComponent, PlayerInputComponent> playerFilter;

    public void Run()
    {
        foreach (var i in playerFilter)
        {
            ref var playerComponent = ref playerFilter.Get1(i);
            ref var playerInputComponent = ref playerFilter.Get2(i);

            playerComponent.playertransform.rotation = Quaternion.Euler(0, Input.mousePosition.x, 0);

            Vector3 dir = playerComponent.playertransform.right * playerInputComponent.x + playerComponent.playertransform.forward * playerInputComponent.y;

            playerComponent.CH.Move(dir * playerComponent.speed);

        }
    }
}

