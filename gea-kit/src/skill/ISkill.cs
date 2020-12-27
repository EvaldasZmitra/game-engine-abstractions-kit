namespace GeaKit.Skill {
    public interface ISkill {
        void Use();
        float Cost { get; }
    }
}