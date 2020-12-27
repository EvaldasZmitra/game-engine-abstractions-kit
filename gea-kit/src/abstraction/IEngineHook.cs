using GameMakingKit.Classes;
using System;
using System.Numerics;

namespace GameMakingKit.Interfaces {
    public interface IEngineHook {
        void DestroyGameobject(IGameObject objectToDestroy);
        void AddUpdate(Action<float> onUpdate, int priority = 0);
        void AddLateUpdate(Action<float> onUpdate, int priority = 0);
        void AddUpdateFixed(Action<float> onUpdate, int priority = 0);
        void FixedUpdate(float dt);
        void LateUpdate(float dt);
        void Update(float dt);
        Vector3? Raycast(Vector3 origin, Vector3 target, float distance = 20);
        T Spawn<T>(IGameObject objectToSpawn);
        IGameObject Spawn(IGameObject objectToSpawn);
    }
}