
using System.Numerics;

namespace GameMakingKit.Interfaces
{
    public interface IRigidbody
    {
        Vector3 Velocity { get; set; }
        ITransform Transform { get; }

        void MovePosition(Vector3 position);
    }
}
