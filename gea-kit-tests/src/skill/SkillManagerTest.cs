using GeaKit.Etc;
using GeaKit.Skill;
using Moq;
using Xunit;

namespace GeaKit.Test {
    public class SkillManagerTest {
        [Theory]
        [InlineData(0, 20, 0, 0)]
        [InlineData(100, 20, 1, 80)]
        public void SkillWhenMana(
            float mana,
            float cost,
            int times,
            float manaLeft
        ) {
            var resource = new Resource<float>(mana, 0, 100);
            var skillManager = new SkillManager(resource);
            var skill = new Mock<ISkill>();
            skill.Setup(it => it.Use());
            skill.Setup(it => it.Cost).Returns(cost);

            skillManager.UseSkill(skill.Object);

            skill.Verify(x => x.Use(), Times.Exactly(times));
            Assert.Equal(manaLeft, resource.Value);
        }
    }
}