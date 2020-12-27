using GeaKit.Etc;

namespace GeaKit.Skill {
    public class SkillManager {
        private readonly Resource<float> _resource;
        private readonly StatusManager _statusManager;

        public SkillManager(
            Resource<float> resource,
            StatusManager statusManager
        ) {
            _resource = resource;
            _statusManager = statusManager;
        }

        public void UseSkill(ISkill skill) {
            if (_resource.Value >= skill.Cost &&
                IsAllowedFromStatus(skill)) {
                _resource.Value -= skill.Cost;
                skill.Use();
            }
        }
        private bool IsAllowedFromStatus(ISkill skill) {
            foreach (var type in skill.CantUseWhen) {
                if (_statusManager.HasStatus(type)) {
                    return false;
                }
            }
            return true;
        }
    }
}