using System.Collections.Generic;

namespace GeaKit.Skill {
    public interface ISkill {
        void Use();
        float Cost { get; }
        List<StatusType> CantUseWhen { get; }
    }
}