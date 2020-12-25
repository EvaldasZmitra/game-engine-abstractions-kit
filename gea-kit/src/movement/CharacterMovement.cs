using System;
using System.Numerics;
using GameMakingKit.Interfaces;

namespace GeaKit.Movement {
    public class CharacterMovement {
        private IRigidbody _rb;
        private IEngineHook _engineHook;
        private bool _hasJumped = false;

        public CharacterMovement(
            IRigidbody rb,
            IEngineHook engineHook
        ) {
            _rb = rb;
            _engineHook = engineHook;
        }

        public void Move(Vector2 velocity) {
            _rb.Velocity = new Vector3(velocity.X, 0, velocity.Y);
        }

        public void Jump(float speed, float jumpDelay = 1.0f) {
            if (!_hasJumped) {
                _hasJumped = true;
                _rb.Velocity += new Vector3(0, speed, 0);
                _engineHook.Delay(
                    TimeSpan.FromSeconds(jumpDelay),
                    () => { _hasJumped = false; }
                );
            }
        }

        public void Rotate(float angle) {
            _rb.Transform.Rotation = new Vector3(0, angle, 0);
        }
    }
}