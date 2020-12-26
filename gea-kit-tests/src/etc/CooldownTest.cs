using System;
using System.Collections.Generic;
using GameMakingKit.Interfaces;
using Moq;
using Xunit;

namespace GeaKit.Etc {
    public class CooldownTest {
        [Fact]
        public void CooldownStarts() {
            var engineHook = new Mock<IEngineHook>();
            Action delayAction = null;
            TimeSpan delay = TimeSpan.FromSeconds(5.0f);

            engineHook.Setup(x => x.Delay(
                delay,
                It.IsAny<Action>()
            )).Callback<TimeSpan, Action>((_, action) => {
                delayAction = action;
            });
            var cooldown = new Cooldown(delay, engineHook.Object);

            Assert.True(cooldown.Ready);
            cooldown.Start();
            Assert.False(cooldown.Ready);
            delayAction.Invoke();
            Assert.True(cooldown.Ready);
        }

        [Fact]
        public void CooldownDoesNotGetInvoedTwice() {
            var engineHook = new Mock<IEngineHook>();
            var delayActions = new List<Action>();
            TimeSpan delay = TimeSpan.FromSeconds(5.0f);
            engineHook.Setup(x => x.Delay(
                delay,
                It.IsAny<Action>()
            )).Callback<TimeSpan, Action>((_, action) => {
                delayActions.Add(action);
            });
            var cooldown = new Cooldown(delay, engineHook.Object);

            cooldown.Start();
            Assert.Single(delayActions);
            cooldown.Start();
            Assert.Single(delayActions);
        }

        [Fact]
        public void CooldownInvokesActionIfReady() {
            var engineHook = new Mock<IEngineHook>();
            Action delayAction = null;
            TimeSpan delay = TimeSpan.FromSeconds(5.0f);
            engineHook.Setup(x => x.Delay(
                delay,
                It.IsAny<Action>()
            )).Callback<TimeSpan, Action>((_, action) => {
                delayAction = action;
            });
            var cooldown = new Cooldown(delay, engineHook.Object);
            var invocationCount = 0;


            cooldown.StartAndDoIfReady(() => {
                invocationCount++;
            });
            Assert.Equal(1, invocationCount);

            cooldown.StartAndDoIfReady(() => {
                invocationCount++;
            });
            Assert.Equal(1, invocationCount);

            delayAction.Invoke();
            cooldown.StartAndDoIfReady(() => {
                invocationCount++;
            });
            Assert.Equal(2, invocationCount);
        }
    }
}