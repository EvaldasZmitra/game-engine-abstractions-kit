using GeaKit.Etc;

namespace GeaKit.Skill {
    public class SkillManager {
        private readonly Resource<float> _resource;

        public SkillManager(Resource<float> resource) {
            _resource = resource;
        }

        public void UseSkill(ISkill skill) {
            if (_resource.Value >= skill.Cost) {
                _resource.Value -= skill.Cost;
                skill.Use();
            }
        }
    }
}