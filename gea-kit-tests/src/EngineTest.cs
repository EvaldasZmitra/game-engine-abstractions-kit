using System;
using GeaKit.Engine;

namespace GeaKit.Test {
    public abstract class EngineTest {
        protected EngineHook _engineHook;

        public EngineTest() {
            _engineHook = new EngineHook();
        }

        protected void LoopEngineTimes(int times, float dt) {
            for (int i = 0; i < times; i++) {
                _engineHook.Update(dt);
                _engineHook.FixedUpdate(dt);
                _engineHook.LateUpdate(dt);
            }
        }
    }
}