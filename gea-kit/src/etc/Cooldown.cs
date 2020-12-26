using System;
using GameMakingKit.Interfaces;

namespace GeaKit.Etc {
    public class Cooldown {
        public bool Ready { get; private set; } = true;
        private readonly TimeSpan _delay;
        private readonly IEngineHook _engineHook;


        public Cooldown(TimeSpan delay, IEngineHook engineHook) {
            _delay = delay;
            _engineHook = engineHook;
        }

        public void Start() {
            Ready = false;
            _engineHook.Delay(_delay, () => {
                Ready = true;
            });
        }
    }
}