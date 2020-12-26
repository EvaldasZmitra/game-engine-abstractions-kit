using Xunit;
using GeaKit.Camera;
using System.Numerics;

namespace GeaKit.Test {
    public class UnitTest1 {
        [Fact]
        public void CameraRotates() {
            CameraRotatesFact(Vector3.Zero, Vector3.UnitX);
            CameraRotatesFact(Vector3.UnitZ, new Vector3(1, 0, 1));
            CameraRotatesFact(Vector3.Zero, Vector3.UnitX * 2, 2);
        }

        private static void CameraRotatesFact(
            Vector3 targetPos,
            Vector3 expectedPos,
            float zoom = 1.0f
        ) {
            var cameraTransform = new Transform();
            var camera = new ThirdPersonCamera(
                cameraTransform,
                new Transform() {
                    Position = targetPos
                },
                zoom
            );

            camera.Rotate(0f, -90f);

            AssertVectorsEqual(expectedPos, cameraTransform.Position);
            Assert.Equal(new Vector3(0f, -90f, 0), cameraTransform.Rotation);
        }

        private static void AssertVectorsEqual(
            Vector3 expected,
            Vector3 actual
        ) {
            Assert.Equal(expected.X, actual.X, 4);
            Assert.Equal(expected.Y, actual.Y, 4);
            Assert.Equal(expected.Z, actual.Z, 4);
        }
    }
}
