using System;
using GameMakingKit.Interfaces;
using GeaKit.Skill;
using Moq;
using Xunit;

namespace GeaKit.Test {
    public class StatusManagerTest : EngineTest {
        [Theory]
        [InlineData(StatusType.CantMove)]
        public void StatusesAreAdded(StatusType type) {
            var manager = new StatusManager(_engineHook);
            var status = new Status() {
                Type = type,
                Duration = TimeSpan.FromSeconds(1.0f)
            };

            manager.AddStatus(status);

            Assert.True(manager.HasStatus(type));
        }

        // [Theory]
        // [InlineData(StatusType.CantMove)]
        // public void StatusesExpire(StatusType type) {
        //     var manager = new StatusManager(_engineHook);
        //     manager.AddStatus(new Status() {
        //         Duration = TimeSpan.FromSeconds(1.0f),
        //         Type = type
        //     });

        //     Assert.True(manager.HasStatus(type));
        //     LoopEngineTimes(6, 1.0f);
        //     Assert.False(manager.HasStatus(type));
        // }
    }
}