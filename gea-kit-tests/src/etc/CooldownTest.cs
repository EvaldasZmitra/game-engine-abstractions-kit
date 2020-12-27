using System;
using System.Collections.Generic;
using GameMakingKit.Interfaces;
using GeaKit.Test;
using Moq;
using Xunit;

namespace GeaKit.Etc {
    public class CooldownTest : EngineTest {
        [Fact]
        public void CooldownStarts() {
            TimeSpan delay = TimeSpan.FromSeconds(5.0f);
            var cooldown = new Cooldown(delay, _engineHook);

            Assert.True(cooldown.Ready);
            cooldown.Start();
            Assert.False(cooldown.Ready);
            LoopEngineTimes(2, 5f);
            Assert.True(cooldown.Ready);
        }

        [Fact]
        public void CooldownInvokesActionIfReady() {
            TimeSpan delay = TimeSpan.FromSeconds(5.0f);
            var cooldown = new Cooldown(delay, _engineHook);
            var invocationCount = 0;


            cooldown.StartAndDoIfReady(() => {
                invocationCount++;
            });
            Assert.Equal(1, invocationCount);
        }
    }
}