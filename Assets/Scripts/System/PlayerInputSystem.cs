using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using UnityEngine.SceneManagement;

public class PlayerInputSystem : IEcsRunSystem 
{
    private EcsFilter<PlayerInputComponent> playerFilter;

    public void Run()
    {
        foreach (var i in playerFilter)
        {
            ref var playerInputComponent = ref playerFilter.Get1(i);

            playerInputComponent.x = Input.GetAxisRaw("Horizontal");
            playerInputComponent.y = Input.GetAxisRaw("Vertical");


            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
