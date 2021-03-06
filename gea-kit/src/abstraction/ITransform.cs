﻿using System.Numerics;

namespace GameMakingKit.Interfaces {
    public interface ITransform {
        Vector3 Position { get; set; }
        Vector3 Rotation { get; set; }
        Vector3 Scale { get; set; }
    }
}
