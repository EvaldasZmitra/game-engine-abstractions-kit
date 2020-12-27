using System;
using System.Numerics;
using GameMakingKit.Classes;
using GameMakingKit.Interfaces;
using GeaKit.Engine;

namespace GeaKit.Test {
    public class EngineHook : IEngineHook {
        private readonly PrioritySortedActions _updates = new();
        private readonly PrioritySortedActions _fixedUpdates = new();
        private readonly PrioritySortedActions _lateUpdates = new();

        public void AddLateUpdate(
            Action<float> onUpdate,
            int priority = 0
        ) {
            _lateUpdates.AddUpdate(onUpdate);
        }

        public void AddUpdate(
            Action<float> onUpdate,
            int priority = 0
        ) {
            _updates.AddUpdate(onUpdate);
        }

        public void AddUpdateFixed(
            Action<float> onUpdate,
            int priority = 0
        ) {
            _fixedUpdates.AddUpdate(onUpdate);
        }

        public void DestroyGameobject(
            IGameObject objectToDestroy
        ) {
            throw new NotImplementedException();
        }

        public Vector3? Raycast(
            Vector3 origin,
            Vector3 target,
            float distance = 20
        ) {
            throw new NotImplementedException();
        }

        public T Spawn<T>(IGameObject objectToSpawn) {
            throw new NotImplementedException();
        }

        public IGameObject Spawn(IGameObject objectToSpawn) {
            throw new NotImplementedException();
        }

        public void Update(float dt) {
            _updates.ExecuteAll(dt);
        }
        public void LateUpdate(float dt) {
            _lateUpdates.ExecuteAll(dt);
        }
        public void FixedUpdate(float dt) {
            _fixedUpdates.ExecuteAll(dt);
        }
    }
}