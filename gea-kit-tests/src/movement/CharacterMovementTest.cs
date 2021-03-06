using System;
using System.Numerics;
using GameMakingKit.Interfaces;
using GeaKit.Movement;
using Moq;
using Xunit;

namespace GeaKit.Test {
    public class CharacterMovementTest : EngineTest {
        [Fact]
        public void MovesTheory() {
            MovesFact(new Vector2(1f, 0), new Vector3(1f, 0, 0));
            MovesFact(new Vector2(0, 10f), new Vector3(0, 0, 10f));
            MovesFact(new Vector2(1f, 1f), new Vector3(1f, 0, 1f));
        }

        private static void MovesFact(
            Vector2 velocityInput,
            Vector3 expectedVelocity
        ) {
            var rb = new RigidBody();
            var characterMovement = new CharacterMovement(
                rb,
                new Mock<IEngineHook>().Object
            );
            characterMovement.Move(velocityInput);

            Assert.Equal(expectedVelocity, rb.Velocity);
        }

        [Fact]
        public void RotatesTheory() {
            RotatesFact(90f, new Vector3(0, 90f, 0));
            RotatesFact(-45f, new Vector3(0, -45f, 0));
        }

        private void RotatesFact(
            float angle,
            Vector3 expectedRotation
        ) {
            var rb = new RigidBody();
            var characterMovement = new CharacterMovement(
                rb,
                _engineHook
            );
            characterMovement.Rotate(angle);

            Assert.Equal(expectedRotation, rb.Transform.Rotation);
        }

        [Fact]
        public void JumpsTheory() {
            JumpsFact(1f, new Vector3(0, 1f, 0));
            JumpsFact(5f, new Vector3(0, 5f, 0));
        }

        private static void JumpsFact(
            float jumpSpeed,
            Vector3 expectedVelocity
        ) {
            var rb = new RigidBody();
            var characterMovement = new CharacterMovement(
                rb,
                new Mock<IEngineHook>().Object
            );
            characterMovement.Jump(jumpSpeed);

            Assert.Equal(expectedVelocity, rb.Velocity);
        }

        [Fact]
        public void JumpsWhileMovingTheory() {
            var rb = new RigidBody();
            var characterMovement = new CharacterMovement(
                rb,
                _engineHook
            );
            characterMovement.Move(new Vector2(0, 1f));
            characterMovement.Jump(1f);

            Assert.Equal(new Vector3(0, 1f, 1f), rb.Velocity);
        }

        [Fact]
        public void CanOnlyJumpOnce() {
            var rb = new RigidBody();
            var characterMovement = new CharacterMovement(
                rb,
                _engineHook
            );

            characterMovement.Jump(1.0f);
            characterMovement.Jump(1.0f);

            Assert.Equal(new Vector3(0, 1.0f, 0), rb.Velocity);
        }

        [Fact]
        public void CanJumpAgainAfterCooldown() {
            var rb = new RigidBody();
            var characterMovement = new CharacterMovement(
                rb,
                _engineHook,
                0.3f
            );

            characterMovement.Jump(1.0f);
            LoopEngineTimes(10, 0.1f);
            characterMovement.Jump(1.0f);

            Assert.Equal(new Vector3(0, 2.0f, 0), rb.Velocity);
        }

        [Fact]
        public void CanOnlyJumpWhenGrounded() {
            var rb = new RigidBody();
            var characterMovement = new CharacterMovement(
                rb,
                _engineHook
            );

            rb.IsGrounded = false;
            characterMovement.Jump(6f);
            Assert.Equal(0, rb.Velocity.Y);
        }
    }
}