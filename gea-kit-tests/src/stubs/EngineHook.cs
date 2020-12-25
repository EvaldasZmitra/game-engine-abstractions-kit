using System;
using System.Collections.Generic;
using System.Numerics;
using GameMakingKit.Classes;
using GameMakingKit.Interfaces;

namespace GeaKit.Test {
    public class EngineHook : IEngineHook {
        private readonly List<Action<float>> _updates = new List<Action<float>>();

        public void AddLateUpdate(
            Action<float> onUpdate,
            int priority = 0
        ) {
        }

        public void AddUpdate(
            Action<float> onUpdate,
            int priority = 0
        ) {
            _updates.Add(onUpdate);
        }

        public void AddUpdateFixed(
            Action<float> onUpdate,
            int priority = 0
        ) {
        }

        public void Delay(
            TimeSpan deltaT,
            Action action
        ) {
            throw new NotImplementedException();
        }

        public void DestroyGameobject(
            IGameObject objectToDestroy
        ) {
            throw new NotImplementedException();
        }

        public void DestroyGameobjectDelay(
            IGameObject objectToDestroy,
            float delay
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
            _updates.ForEach(x => x.Invoke(dt));
        }
    }
}