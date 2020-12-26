using System.Numerics;
using GameMakingKit.Interfaces;

namespace GeaKit.Test {
    public class RigidBody : IRigidbody {
        public Vector3 Velocity { get; set; }

        public ITransform Transform { get; set; } = new Transform();

        public bool IsGrounded { get; set; } = true;

        public void MovePosition(Vector3 position) {
            Transform.Position += position;
        }
    }
}