using System.Numerics;
using GameMakingKit.Interfaces;

namespace GeaKit.Test {
    public class Transform : ITransform {
        public Vector3 Position { get; set; } = new Vector3();
        public Vector3 Rotation { get; set; } = new Vector3();
        public Vector3 Scale { get; set; } = new Vector3();
    }
}