using GameMakingKit.Interfaces;

namespace GameMakingKit.Classes
{
    public interface IGameObject
    {
        ITransform Transform { get; set; }
        bool ActiveSelf { get; }
        void SetActive(bool active);
        object Reference { get; set; }
    }
}
