using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

public class Startup : MonoBehaviour
{
    private EcsWorld ecsworld;
    private EcsSystems initSystems;
    private EcsSystems updateSystems;
    private EcsSystems fixedUpdateSystems;


    // Start is called before the first frame update
    void Start()
    {
        ecsworld = new EcsWorld();

        initSystems = new EcsSystems(ecsworld)
            .Add(new PlayerInitSystem());
        updateSystems = new EcsSystems(ecsworld)
            .Add(new PlayerInputSystem());
        fixedUpdateSystems = new EcsSystems(ecsworld)
            .Add(new PlayerMoveSystem())
            .Add(new CameraRotationSystem());

        initSystems.ProcessInjects();
        updateSystems.ProcessInjects();
        fixedUpdateSystems.ProcessInjects();

        initSystems.Init();
        updateSystems.Init();
        fixedUpdateSystems.Init();

    }



    private void Update()
    {
        updateSystems.Run();
    }

    private void FixedUpdate()
    {
        fixedUpdateSystems.Run();
    }
}
