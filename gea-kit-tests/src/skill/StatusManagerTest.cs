using System;
using GameMakingKit.Interfaces;
using GeaKit.Skill;
using Moq;
using Xunit;

namespace GeaKit.Test {
    public class StatusManagerTest {
        [Theory]
        [InlineData(StatusType.CantMove)]
        public void StatusesAreAdded(StatusType type) {
            var hook = new Mock<IEngineHook>();
            hook.Setup(x =>
                x.Delay(
                    TimeSpan.FromSeconds(1.0f),
                    It.IsAny<Action>()
                )
            );
            var manager = new StatusManager(hook.Object);
            var status = new Status() {
                Type = type,
                Duration = TimeSpan.FromSeconds(1.0f)
            };

            manager.AddStatus(status);

            Assert.True(manager.HasStatus(type));
        }

        [Theory]
        [InlineData(StatusType.CantMove)]
        public void StatusesExpire(StatusType type) {
            var hook = new Mock<IEngineHook>();
            Action delayAction = null;
            hook.Setup(x =>
                x.Delay(
                    TimeSpan.FromSeconds(1.0f),
                    It.IsAny<Action>()
                )
            ).Callback<TimeSpan, Action>(
                (_, action) => {
                    delayAction = action;
                }
            );
            var manager = new StatusManager(hook.Object);
            manager.AddStatus(new Status() {
                Duration = TimeSpan.FromSeconds(1.0f),
                Type = type
            });

            Assert.True(manager.HasStatus(type));
            delayAction.Invoke();
            Assert.False(manager.HasStatus(type));
        }
    }
}