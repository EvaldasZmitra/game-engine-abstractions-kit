using System;
using GeaKit.Etc;

namespace GeaKit.Skill {
    public enum StatusType {
        CantMove,
        CantUseSkill
    }

    [Serializable]
    public struct Status {
        public Cooldown Cooldown;
        public StatusType Type;
    }
}