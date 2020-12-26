using System;
using System.Numerics;
using GameMakingKit.Interfaces;
using GeaKit.Etc;

namespace GeaKit.Movement {
    public class CharacterMovement {
        private readonly IRigidbody _rb;
        private readonly Cooldown _cooldown;

        public CharacterMovement(
            IRigidbody rb,
            IEngineHook engineHook,
            float jumpCooldown = 0.3f
        ) {
            _rb = rb;
            _cooldown = new(TimeSpan.FromSeconds(jumpCooldown), engineHook);
        }

        public void Move(Vector2 velocity) {
            _rb.Velocity = new Vector3(velocity.X, 0, velocity.Y);
        }

        public void Jump(float speed) {
            if (_rb.IsGrounded) {
                _cooldown.StartAndDoIfReady(() => {
                    _rb.Velocity += new Vector3(0, speed, 0);
                });
            }
        }

        public void Rotate(float angle) {
            _rb.Transform.Rotation = new Vector3(0, angle, 0);
        }
    }
}