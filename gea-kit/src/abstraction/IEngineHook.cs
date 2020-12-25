using GameMakingKit.Classes;
using System;
using System.Numerics;

namespace GameMakingKit.Interfaces {
    public interface IEngineHook {
        void DestroyGameobject(IGameObject objectToDestroy);
        void DestroyGameobjectDelay(IGameObject objectToDestroy, float delay);
        void AddUpdate(Action<float> onUpdate, int priority = 0);
        void AddLateUpdate(Action<float> onUpdate, int priority = 0);
        void AddUpdateFixed(Action<float> onUpdate, int priority = 0);
        void Update(float dt);
        Vector3? Raycast(Vector3 origin, Vector3 target, float distance = 20);
        T Spawn<T>(IGameObject objectToSpawn);
        IGameObject Spawn(IGameObject objectToSpawn);
        void Delay(TimeSpan deltaT, Action action);
    }
}