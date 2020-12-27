using System;

namespace GeaKit.Skill {
    public enum StatusType {
        CantMove,
        CantUseSkill
    }

    [Serializable]
    public struct Status {
        public TimeSpan Duration;
        public StatusType Type;
    }
}