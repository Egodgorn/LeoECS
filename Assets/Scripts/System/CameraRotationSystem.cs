using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

public class CameraRotationSystem : IEcsRunSystem, IEcsInitSystem
{
    private EcsWorld ecsworld;

    private EcsFilter<CameraComponent> cameraFilter;
    public void Init()
    {
        var cameraentity = ecsworld.NewEntity();

        ref var cameracomponent = ref cameraentity.Get<CameraComponent>();

        cameracomponent.Transformcamera = Camera.main.transform;
    }
    public void Run()
    {
        foreach (var i in cameraFilter)
        {
            ref var cameraComponent = ref cameraFilter.Get1(i);

            cameraComponent.Transformcamera.localRotation = Quaternion.Euler( Mathf.Clamp(-Input.mousePosition.y,-90f,70f),cameraComponent.Transformcamera.rotation.y,0);

        }
    }
}
