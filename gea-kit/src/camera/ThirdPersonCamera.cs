using System;
using System.Numerics;
using GameMakingKit.Interfaces;

namespace GeaKit.Camera {
    public class ThirdPersonCamera {
        private readonly ITransform _transform;
        private readonly ITransform _focusPoint;
        public float Zoom { get; set; } = 1f;

        public ThirdPersonCamera(
            ITransform transform,
            ITransform focusPoint,
            float zoom
        ) {
            _transform = transform;
            _focusPoint = focusPoint;
            Zoom = zoom;
        }

        public void Rotate(float pitch, float yaw) {
            _transform.Rotation = new Vector3(
                pitch + _transform.Rotation.X,
                yaw + _transform.Rotation.Y,
                0
            );
            var q = Quaternion.CreateFromYawPitchRoll(
                (float)(_transform.Rotation.Y / 180f * Math.PI),
                (float)(_transform.Rotation.X / 180f * Math.PI),
                0
            );
            var r = q *
                new Quaternion(-Vector3.UnitZ * Zoom, 0) *
                Quaternion.Conjugate(q);
            _transform.Position = _focusPoint.Position +
                new Vector3(r.X, r.Y, r.Z);
        }
    }
}
