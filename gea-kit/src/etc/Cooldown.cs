using System;
using GameMakingKit.Interfaces;

namespace GeaKit.Etc {
    public class Cooldown {
        public bool Ready { get; private set; } = true;
        private readonly TimeSpan _delay;
        private float _counter;

        private Action _onReadyAction;


        public Cooldown(TimeSpan delay, IEngineHook engineHook) {
            _delay = delay;
            engineHook.AddUpdate(Update);
        }

        public void Start() {
            Ready = false;
            _counter = 0;
        }

        public void StartAndDoIfReady(Action action) {
            if (Ready) {
                Start();
                action.Invoke();
            }
        }

        public void StartAndDoWhenCompleted(Action action) {
            if (Ready) {
                Start();
                _onReadyAction = action;
            }
        }

        private void Update(float dt) {
            if (!Ready) {
                if (_counter >= _delay.TotalSeconds) {
                    if (_onReadyAction != null) {
                        _onReadyAction.Invoke();
                        _onReadyAction = null;
                    }
                    Ready = true;
                    return;
                }
                _counter += dt;
            }
        }
    }
}