using System;
using System.Collections.Generic;
using GeaKit.Etc;
using GeaKit.Skill;
using Moq;
using Xunit;

namespace GeaKit.Test {
    public class SkillManagerTest : EngineTest {
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
            var statusManager = new StatusManager(_engineHook);
            var skillManager = new SkillManager(resource, statusManager);
            var skill = new Mock<ISkill>();
            skill.Setup(it => it.Use());
            skill.Setup(it => it.Cost).Returns(cost);
            skill.Setup(it => it.CantUseWhen).Returns(
                new List<StatusType>() {
                    StatusType.CantMove
                }
            );
            skillManager.UseSkill(skill.Object);

            skill.Verify(x => x.Use(), Times.Exactly(times));
            Assert.Equal(manaLeft, resource.Value);
        }

        [Fact]
        public void SkillWhenStatus() {
            var resource = new Resource<float>(100, 0, 100);
            var skill = new Mock<ISkill>();
            var statusManager = new StatusManager(_engineHook);
            var skillManager = new SkillManager(resource, statusManager);
            skill.Setup(it => it.Use());
            skill.Setup(it => it.Cost).Returns(0);
            skill.Setup(it => it.CantUseWhen).Returns(
                new List<StatusType>() {
                    StatusType.CantMove
                }
            );
            statusManager.AddStatus(new Status() {
                Type = StatusType.CantMove,
                Cooldown = new Cooldown(TimeSpan.FromSeconds(99f), _engineHook)
            });

            skillManager.UseSkill(skill.Object);

            skill.Verify(x => x.Use(), Times.Never());
        }
    }
}